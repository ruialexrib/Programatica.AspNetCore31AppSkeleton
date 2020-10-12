using Microsoft.AspNetCore.Mvc;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.Framework.Services;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class DummyController : Controller
    {
        private readonly IService<Dummy> _dummyService;

        public DummyController(IService<Dummy> dummyService)
        {
            _dummyService = dummyService;
        }

        // GET: DummyController
        public ActionResult Index()
        {
            var r = _dummyService.Get();
            return View(r);
        }

        
    }
}
