using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Programatica.AspNetCore31AppSkeleton.Services;
using Programatica.AspNetCore31AppSkeleton.ViewModels;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Login()
        {
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
                    return View(vm);
                }
            }else
            {
                return View(vm);
            }
        }

        public IActionResult Logoff()
        {
            _authenticationService.SignOut(HttpContext);
            return RedirectToAction("Login", "Account", null);
        }
    }
}
