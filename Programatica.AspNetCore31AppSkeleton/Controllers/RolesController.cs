using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.AspNetCore31AppSkeleton.ViewModels.Base;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Mvc.Controllers;
using Programatica.Framework.Mvc.Filters;
using Programatica.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    [AuthorizedRole(roles: new string[] { "Administrators" })]
    public class RolesController : EJ2DataGridBaseController<Role>
    {
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IService<Role> _roleService;
        protected readonly ILogger<RolesController> _logger;
        protected readonly IMapper _mapper;


        public RolesController(
            IService<Role> roleService,
            IMapper mapper,
            ILogger<RolesController> logger,
            IRepository<UserRole> userRoleRepository)
        {
            _roleService = roleService;
            _mapper = mapper;
            _logger = logger;
            _userRoleRepository = userRoleRepository;
        }

        protected override async Task<IEnumerable<Role>> LoadDataAsync()
        {
            var data = await _roleService.GetAsync();
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
        public virtual async Task<JsonResult> Create([FromBody] RoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = await _roleService.CreateAsync(_mapper.Map<Role>(vm));
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
            Role entity = await _roleService.InspectAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<RoleViewModel>(entity);
            return PartialView("_Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<JsonResult> Edit([FromBody] RoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _roleService.ModifyAsync(_mapper.Map<Role>(vm));
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
                await _roleService.DeleteAsync(vm.Id);
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
