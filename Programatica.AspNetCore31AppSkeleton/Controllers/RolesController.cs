using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.Controllers.Base;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Services;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class RolesController : BaseModelController<Role, RoleViewModel, RolesController>
    {

        public RolesController(
            IService<Role> roleService,
            IMapper mapper,
            ILogger<RolesController> logger)
            : base(roleService, mapper, logger)
        {
        }

    }
}
