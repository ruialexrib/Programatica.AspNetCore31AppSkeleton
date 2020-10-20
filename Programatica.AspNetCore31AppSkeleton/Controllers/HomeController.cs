using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.Models;
using Programatica.AspNetCore31AppSkeleton.Services;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public HomeController(ILogger<HomeController> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult License()
        {
            return View();
        }

        public IActionResult Credits()
        {
            return View();
        }

        public IActionResult Login()
        {
            _authenticationService.SignIn(HttpContext, "ruialexrib");
            return RedirectToAction("Index", "Home", null);
        }

        public IActionResult Logoff()
        {
            _authenticationService.SignOut(HttpContext);
            return RedirectToAction("Index", "Home", null);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
