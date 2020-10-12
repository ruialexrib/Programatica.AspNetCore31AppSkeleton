using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class ModalController : Controller
    {
        // GET: ModalController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Modal()
        {
            return PartialView("_Modal");
        }
    }
}
