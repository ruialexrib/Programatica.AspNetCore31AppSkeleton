using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programatica.AspNetCore31AppSkeleton.Controllers.Base;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Services;
using Programatica.Framework.Data.Repository;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Modal()
        {
            return await Task.Run(() => PartialView("_Modal"));
        }

        [HttpGet]
        public async Task<IActionResult> Modal2()
        {
            return await Task.Run(() => PartialView("_Modal2"));
        }

    }
}
