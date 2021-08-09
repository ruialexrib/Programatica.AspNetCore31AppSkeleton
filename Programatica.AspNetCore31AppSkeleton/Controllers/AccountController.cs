using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.Filters;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Mvc.Authentication;
using Programatica.Framework.Mvc.Controllers;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            IAuthenticationService authenticationService,
            ILogger<AccountController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        public async Task<IActionResult> Login()
        {
            PageMessages.Add("For demo purpose insert 'username: admin' and 'password: pass'");
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _authenticationService.SignIn(HttpContext,
                                                        vm.Username,
                                                        vm.Password,
                                                        vm.IsPersistent)
                                                .ConfigureAwait(false);

                    return RedirectToAction("Index", "Home", null);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    PageAlerts.Add(e.Message);
                    return View(vm);
                }
            }
            else
            {
                PageAlerts.Add("Model validation errors.");
                return View(vm);
            }
        }

        [AuthorizedRole(roles: new string[] { "Administrators", "Users" })]
        public async Task<IActionResult> Logoff()
        {
            await _authenticationService.SignOut(HttpContext);
            return RedirectToAction("Login", "Account", null);
        }

        public async Task<IActionResult> AccessDenied()
        {
            PageAlerts.Add("Access Denied");
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> TermsOfUse()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> License()
        {
            return await Task.Run(() => View());
        }
    }
}
