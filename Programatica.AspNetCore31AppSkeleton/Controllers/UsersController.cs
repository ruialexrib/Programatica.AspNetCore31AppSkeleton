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

    public class UsersController : BaseModelController<User>
    {
        private readonly IService<User> _userService;
        private readonly IMapper _mapper;

        public UsersController(
            IService<User> userService, 
            IMapper mapper)
            :base(userService)
        {
            _userService = userService;
            _mapper = mapper;

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([FromBody] UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.Create(_mapper.Map<User>(vm));
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
            User user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<UserViewModel>(user);
            return PartialView("_Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([FromBody] UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.Modify(_mapper.Map<User>(vm));
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
                _userService.Delete(vm.Id);
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
