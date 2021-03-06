﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Services;
using Programatica.Framework.Mvc.Controllers;
using Programatica.Framework.Mvc.Filters;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Programatica.AspNetCore31AppSkeleton.ViewModels.Base;
using System.ComponentModel;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UsersController : EJ2DataGridBaseController<User>
    {
        private readonly IService<User> _userService;
        protected readonly ILogger<UsersController> _logger;
        protected readonly IMapper _mapper;

        public UsersController(
            IService<User> userService,
            IMapper mapper,
            ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        protected override async Task<IEnumerable<User>> LoadDataAsync()
        {
            var data = await _userService.GetAsync();
            return data;
        }

        [HttpGet]
        [AuthorizedAction(permission: "Teste")]
        [DisplayName("Manage User List")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DisplayName("Open New User Details Form")]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("Save New User Details Data")]
        public virtual async Task<JsonResult> Create([FromBody] UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = await _userService.CreateAsync(_mapper.Map<User>(vm));
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
        [DisplayName("Open User Details Form")]
        public virtual async Task<IActionResult> Edit(int id)
        {
            User entity = await _userService.InspectAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<UserViewModel>(entity);
            return PartialView("_Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("Save User Details Data")]
        public virtual async Task<JsonResult> Edit([FromBody] UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.ModifyAsync(_mapper.Map<User>(vm));
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
        [DisplayName("Delete User Details Data")]
        public virtual async Task<JsonResult> Delete([FromBody] DeleteViewModel vm)
        {
            try
            {
                await _userService.DeleteAsync(vm.Id);
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

        [HttpGet]
        [DisplayName("Open Modal Form")]
        public IActionResult Modal()
        {
            PageMessages.Add("Messagem from controller in modal window");
            return PartialView("_Modal");
        }

    }
}
