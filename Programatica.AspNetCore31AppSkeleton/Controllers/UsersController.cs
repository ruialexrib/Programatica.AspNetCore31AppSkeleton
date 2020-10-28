using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.Controllers.Base;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Services;
using Syncfusion.EJ2.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using Programatica.Framework.Data.Repository;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UsersController : BaseModelController<User, UserViewModel, UsersController>
    {
        private readonly IRepository<Audit> _auditRepository;

        public UsersController(
            IService<User> userService,
            IMapper mapper,
            ILogger<UsersController> logger,
            IRepository<Audit> auditRepository)
            : base(userService, mapper, logger)
        {
            _auditRepository = auditRepository;
        }

        [HttpGet]
        public IActionResult Modal()
        {
            return PartialView("_Modal");
        }

        [HttpGet]
        public IActionResult Modal2()
        {
            return PartialView("_Modal2");
        }

    }
}
