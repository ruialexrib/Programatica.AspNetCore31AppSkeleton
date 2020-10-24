using System;
using System.Collections;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Programatica.AspNetCore31AppSkeleton.ViewModels.Base;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Services;
using Syncfusion.EJ2.Base;

namespace Programatica.AspNetCore31AppSkeleton.Controllers.Base
{
    public class BaseModelController<TModel, TViewModel> : BaseController
        where TModel : IModel
        where TViewModel : class
    {
        protected readonly IService<TModel> _modelService;
        private readonly IMapper _mapper;

        public BaseModelController(
            IService<TModel> modelService, 
            IMapper mapper)
        {
            _modelService = modelService;
            _mapper = mapper;
        }

        public virtual IActionResult Index()
        {
            return View();
        }

        public virtual ActionResult UrlDatasource([FromBody] DataManagerRequest dm)
        {
            IEnumerable DataSource = _modelService.Get();

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

            int count = DataSource.Cast<TModel>().Count();

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
        public virtual IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual JsonResult Create([FromBody] TViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _modelService.Create(_mapper.Map<TModel>(vm));
                    return new JsonResult(new { result = "ok" })
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                catch (Exception e)
                {
                    return new JsonResult(new { result = "error", message = e.Message })
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
            }
            else
            {
                return new JsonResult(new { result = "error", message = "Invalid Model" })
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [HttpGet]
        public virtual IActionResult Edit(int id)
        {
            TModel tmodel = _modelService.Get(id);
            if (tmodel == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<TViewModel>(tmodel);
            return PartialView("_Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual JsonResult Edit([FromBody] TViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _modelService.Modify(_mapper.Map<TModel>(vm));
                    return new JsonResult(new { result = "ok" })
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                catch (Exception e)
                {
                    return new JsonResult(new { result = "error", message = e.Message })
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
            }
            else
            {
                return new JsonResult(new { result = "error", message = "Invalid Model" })
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [HttpPost]
        public virtual JsonResult Delete([FromBody] DeleteViewModel vm)
        {
            try
            {
                _modelService.Delete(vm.Id);
                return new JsonResult(new { result = "ok" })
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception e)
            {
                return new JsonResult(new { result = "error", message = e.Message })
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

        }
    }
}
