using Microsoft.AspNetCore.Mvc;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.Models;
using Programatica.Framework.Services;
using Syncfusion.EJ2.Base;
using System.Collections;
using System.Linq;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class GridController : Controller
    {
        private readonly IService<Dummy> _dummyService;

        public GridController(IService<Dummy> dummyService)
        {
            _dummyService = dummyService;
        }


        // GET: GridController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UrlDatasource([FromBody] DataManagerRequest dm)
        {
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
    }
}
