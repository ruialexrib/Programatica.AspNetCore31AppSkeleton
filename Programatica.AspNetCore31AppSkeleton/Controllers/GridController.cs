using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Programatica.AspNetCore31AppSkeleton.Controllers.Base;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Services;
using System;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GridController : BaseModelController<Dummy>
    {
        private readonly IService<Dummy> _dummyService;
        private readonly IMapper _mapper;

        public GridController(
            IService<Dummy> dummyService, 
            IMapper mapper)
            :base(dummyService)
        {
            _dummyService = dummyService;
            _mapper = mapper;

            PageMessages.Add("Message from GridController Constructor");
            PageWarnings.Add("Warning from GridController Constructor");
            PageAlerts.Add("Alert from GridController Constructor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([FromBody] DummyViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _dummyService.Create(_mapper.Map<Dummy>(vm));
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
                try
                {
                    _dummyService.Modify(_mapper.Map<Dummy>(vm));
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
        public JsonResult Delete([FromBody] DummyViewModel vm)
        {
            try
            {
                _dummyService.Delete(vm.Id);
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
