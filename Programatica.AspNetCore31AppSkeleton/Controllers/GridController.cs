using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.AspNetCore31AppSkeleton.ViewModels.Base;
using Programatica.Framework.Mvc.Controllers;
using Programatica.Framework.Mvc.Filters;
using Programatica.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    [AuthorizedRole(roles: new string[] { "Administrators", "Users" })]
    public class GridController : EJ2DataGridBaseController<Dummy>
    {
        private readonly IService<Dummy> _dummyService;
        protected readonly ILogger<GridController> _logger;
        protected readonly IMapper _mapper;

        public GridController(
            IService<Dummy> dummyService,
            IMapper mapper,
            ILogger<GridController> logger)
        {
            _dummyService = dummyService;
            _mapper = mapper;
            _logger = logger;

            // add some test messages
            PageMessages.Add("Message from GridController Constructor");
            PageWarnings.Add("Warning from GridController Constructor");
            PageAlerts.Add("Alert from GridController Constructor");
        }

        protected override IQueryable<Dummy> LoadData()
        {
            var data = _dummyService.Get();
            return data;
        }

        [HttpGet]
        [AuthorizedAction(permission: "Teste")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<JsonResult> Create([FromBody] DummyViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = await _dummyService.CreateAsync(_mapper.Map<Dummy>(vm));
                    return new JsonResult(new { result = "ok", id = m.Id.ToString() })
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
        public virtual async Task<IActionResult> Edit(int id)
        {
            Dummy entity = await _dummyService.InspectAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<DummyViewModel>(entity);
            return PartialView("_Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<JsonResult> Edit([FromBody] DummyViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _dummyService.ModifyAsync(_mapper.Map<Dummy>(vm));
                    return new JsonResult(new { result = "ok", id = vm.Id.ToString() })
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
        public virtual async Task<JsonResult> Delete([FromBody] DeleteViewModel vm)
        {
            try
            {
                await _dummyService.DeleteAsync(vm.Id);
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
