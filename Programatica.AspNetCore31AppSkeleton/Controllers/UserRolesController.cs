using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.Filters;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.AspNetCore31AppSkeleton.ViewModels.Base;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Mvc.Controllers;
using Programatica.Framework.Mvc.Filters;
using Programatica.Framework.Services;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    [AuthorizedRole(roles: new string[] { "Administrators"})]
    public class UserRolesController : EJ2DataGridBaseController<UserRoleViewModel>
    {
        private readonly IService<UserRole> _userRoleService;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        protected readonly ILogger<UserRolesController> _logger;
        protected readonly IMapper _mapper;

        public UserRolesController(
            IService<UserRole> userRoleService,
            IRepository<User> userRepository,
            IRepository<Role> roleRepository,
            IMapper mapper,
            ILogger<UserRolesController> logger)
        {
            _userRoleService = userRoleService;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        protected override async Task<IEnumerable<UserRoleViewModel>> LoadDataAsync()
        {
            var userroles = await _userRoleService.GetAsync(x => x.Include(z => z.User)
                                                                  .Include(z => z.Role));

            IEnumerable<UserRoleViewModel> data = userroles
                                                  .Select(s => new UserRoleViewModel
                                                  {
                                                      Id = s.Id,
                                                      UserName = s.User.Username,
                                                      UserId = s.UserId,
                                                      RoleName = s.Role.Name,
                                                      RoleId = s.RoleId,
                                                      Comments = s.Comments,
                                                      LastModifiedDate = s.LastModifiedDate,
                                                      LastModifiedUser = s.LastModifiedUser
                                                  });
            return data;
        }

        [HttpGet]
        [AuthorizedAction(permission: "Teste")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? userId)
        {
            var vm = new UserRoleViewModel
            {
                ListOfUsers = (await _userRepository.GetDataAsync()).ToList(),
                ListOfRoles = (await _roleRepository.GetDataAsync()).ToList(),
                SelectedUserId = userId,
                CanChangeUser = userId == null
            };

            return PartialView("_Create", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<JsonResult> Create([FromBody] UserRoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = await _userRoleService.CreateAsync(_mapper.Map<UserRole>(vm));
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
        public async Task<IActionResult> Edit(int id)
        {
            UserRole entity = await _userRoleService.GetAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<UserRoleViewModel>(entity);

            vm.ListOfUsers = (await _userRepository.GetDataAsync()).ToList();
            vm.ListOfRoles = (await _roleRepository.GetDataAsync()).ToList();

            return PartialView("_Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<JsonResult> Edit([FromBody] UserRoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userRoleService.ModifyAsync(_mapper.Map<UserRole>(vm));
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
                await _userRoleService.DeleteAsync(vm.Id);
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
        public async Task<IActionResult> IndexByUser(int userId)
        {
            var userRoles = (await _userRoleService.GetAsync(x => x.Include(z => z.User)
                                                                   .Include(z => z.Role)))
                                   .Where(x => x.UserId.Equals(userId))
                                   .Select(x => new UserRoleViewModel
                                   {
                                       Id = x.Id,
                                       SystemId = x.SystemId,
                                       UserId = x.UserId,
                                       UserName = x.User.Username,
                                       RoleId = x.RoleId,
                                       RoleName = x.Role.Name,
                                       Comments = x.Comments,
                                       CreatedDate = x.CreatedDate,
                                       CreatedUser = x.CreatedUser
                                   })
                                   .ToList();

            var vm = new UserRolesByUserViewModel
            {
                ListOfUserRoleViewModel = userRoles,
                UserId = userId
            };

            return PartialView("_IndexByUser", vm);
        }

    }
}
