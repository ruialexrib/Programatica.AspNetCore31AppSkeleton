using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Mvc.Authentication;
using Programatica.Framework.Mvc.Controllers;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
#pragma warning disable IDE0052 // Remove unread private members
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            IAuthenticationService authenticationService,
            ILogger<AccountController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        public IActionResult Login()
        {
            PageMessages.Add("For demo purpose insert 'username: admin' and 'password: pass'");
            return View();
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

        [Authorize(Roles = "Administrators, Users")]
        public IActionResult Logoff()
        {
            _authenticationService.SignOut(HttpContext);
            return RedirectToAction("Login", "Account", null);
        }

        public IActionResult AccessDenied()
        {
            PageAlerts.Add("Access Denied");
            return View();
        }
    }
}
