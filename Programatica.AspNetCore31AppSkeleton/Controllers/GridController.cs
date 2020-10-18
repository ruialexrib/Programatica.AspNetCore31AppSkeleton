using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Services;
using Syncfusion.EJ2.Base;
using System.Collections;
using System.Linq;
using System.Threading;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class GridController : Controller
    {
        private readonly IService<Dummy> _dummyService;
        private readonly IMapper _mapper;

        public GridController(IService<Dummy> dummyService, IMapper mapper)
        {
            _dummyService = dummyService;
            _mapper = mapper;
        }

        // GET: GridController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UrlDatasource([FromBody] DataManagerRequest dm)
        {
            Thread.Sleep(5000);

            IEnumerable DataSource = _dummyService.Get();

            DataOperations operation = new DataOperations();

            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            }

            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }

            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }

            int count = DataSource.Cast<Dummy>().Count();

            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count }) : Json(DataSource);
        }




        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([FromBody] DummyViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _dummyService.Create(_mapper.Map<Dummy>(vm));
                return Json(new { result = "ok" });
            }
            else
            {
                return Json(new { result = "error" });
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Dummy dummy = _dummyService.Get(id);
            if (dummy == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<DummyViewModel>(dummy);
            return PartialView("_Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([FromBody] DummyViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _dummyService.Modify(_mapper.Map<Dummy>(vm));
                return Json(new { result = "ok" });
            }
            else
            {
                return Json(new { result = "error" });
            }
        }

        [HttpPost]
        public JsonResult Delete([FromBody] DummyViewModel vm)
        {
            _dummyService.Delete(vm.Id);
            return Json(new { result = "ok" });
        }
    }
}
