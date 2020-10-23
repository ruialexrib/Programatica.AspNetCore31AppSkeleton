using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Programatica.AspNetCore31AppSkeleton.Controllers.Base;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Services;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class RolesController : BaseModelController<Role>
    {
        private readonly IService<Role> _roleService;
        private readonly IMapper _mapper;

        public RolesController(
            IService<Role> roleService,
            IMapper mapper)
            : base(roleService)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([FromBody] RoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var role = _mapper.Map<Role>(vm);
                    _roleService.Create(role);
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
            Role role = _roleService.Get(id);
            if (role == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<RoleViewModel>(role);
            return PartialView("_Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([FromBody] RoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _roleService.Modify(_mapper.Map<Role>(vm));
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
        public JsonResult Delete([FromBody] UserViewModel vm)
        {
            try
            {
                _roleService.Delete(vm.Id);
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
