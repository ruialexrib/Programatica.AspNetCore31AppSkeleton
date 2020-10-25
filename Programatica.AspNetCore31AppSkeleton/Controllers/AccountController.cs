using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.Adapters;
using Programatica.AspNetCore31AppSkeleton.Controllers.Base;
using Programatica.AspNetCore31AppSkeleton.Services;
using Programatica.AspNetCore31AppSkeleton.ViewModels;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AccountController> _logger;
        private readonly IPageAdapter _pageAdapter;

        public AccountController(
            IAuthenticationService authenticationService,
            ILogger<AccountController> logger,
            IPageAdapter pageAdapter)
        {
            _authenticationService = authenticationService;
            _logger = logger;
            _pageAdapter = pageAdapter;
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
                    await _authenticationService.SignIn(HttpContext, vm.Username, vm.Password, vm.IsPersistent);
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

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
