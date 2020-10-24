using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Programatica.AspNetCore31AppSkeleton.Controllers.Base;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services;
using Syncfusion.EJ2.Base;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class PermissionsController : BaseModelController<UserRole, PermissionViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;

        public PermissionsController(
            IService<UserRole> modelService,
            IMapper mapper,
            IRepository<User> userRepository,
            IRepository<Role> roleRepository)
            : base(modelService, mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }


        public override ActionResult UrlDatasource([FromBody] DataManagerRequest dm)
        {
            //join data
            IEnumerable DataSource = _modelService.Get()
                                        .Join(_userRepository.GetData(),
                                            ur => ur.UserId,
                                            u => u.Id,
                                            (ur, u) => new { ur, u })
                                        .Join(_roleRepository.GetData(),
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
        public override IActionResult Create()
        {
            var vm = new PermissionViewModel
            {
                ListOfUsers = _userRepository.GetData().ToList(),
                ListOfRoles = _roleRepository.GetData().ToList()
            };

            return PartialView("_Create", vm);
        }

    }
}
