using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.Controllers.Base;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services;
using Syncfusion.EJ2.Base;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class PermissionsController : BaseModelController<UserRole, PermissionViewModel, PermissionsController>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;

        public PermissionsController(
            IService<UserRole> modelService,
            IMapper mapper,
            ILogger<PermissionsController> logger,
            IRepository<User> userRepository,
            IRepository<Role> roleRepository)
            : base(modelService, mapper, logger)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }


        public override async Task<ActionResult> UrlDatasource([FromBody] DataManagerRequest dm)
        {
            //join data
            IEnumerable DataSource = (await _modelService.GetAsync())
                                                  .Join(await _userRepository.GetDataAsync(),
                                                        ur => ur.UserId,
                                                        u => u.Id,
                                                        (ur, u) => new { ur, u })
                                                  .Join(await _roleRepository.GetDataAsync(),
                                                        j1 => j1.ur.RoleId,
                                                        r => r.Id,
                                                        (j1, r) => new { j1, r })
                                                  .Select(s => new PermissionViewModel
                                                  {
                                                      Id = s.j1.ur.Id,
                                                      Username = s.j1.u.Username,
                                                      UserId = s.j1.u.Id,
                                                      Role = s.r.Name,
                                                      RoleId = s.r.Id,
                                                      LastModifiedDate = s.j1.ur.LastModifiedDate,
                                                      LastModifiedUser = s.j1.ur.LastModifiedUser
                                                  });

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

            int count = DataSource.Cast<PermissionViewModel>().Count();

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
        public override async Task<IActionResult> Create()
        {
            var vm = new PermissionViewModel
            {
                ListOfUsers = (await _userRepository.GetDataAsync()).ToList(),
                ListOfRoles = (await _roleRepository.GetDataAsync()).ToList()
            };

            return PartialView("_Create", vm);
        }

        [HttpGet]
        public override async Task<IActionResult> Edit(int id)
        {
            UserRole tmodel = await _modelService.GetAsync(id);
            if (tmodel == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<PermissionViewModel>(tmodel);

            vm.ListOfUsers = _userRepository.GetData().ToList();
            vm.ListOfRoles = _roleRepository.GetData().ToList();

            return PartialView("_Edit", vm);
        }

    }
}
