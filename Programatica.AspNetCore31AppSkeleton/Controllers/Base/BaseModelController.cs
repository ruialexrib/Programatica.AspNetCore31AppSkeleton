using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.ViewModels.Base;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Mvc.Controllers;
using Programatica.Framework.Services;

namespace Programatica.AspNetCore31AppSkeleton.Controllers.Base
{
    public class BaseModelController<TModel, TViewModel, TController> : EJ2DataGridBaseController<TModel>
        where TModel : IModel
        where TViewModel : class
        where TController : BaseModelController<TModel, TViewModel, TController>
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<TController> _logger;

        public BaseModelController(
            IService<TModel> modelService,
            IMapper mapper,
            ILogger<TController> logger)
            : base(modelService)
        {
            _mapper = mapper;
            _logger = logger;

        }

        public virtual IActionResult Index()
        {
            return View();
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
                        StatusCode = StatusCodes.Status400BadRequest
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
                        StatusCode = StatusCodes.Status400BadRequest
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
