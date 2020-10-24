using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Programatica.AspNetCore31AppSkeleton.Controllers.Base;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Services;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UsersController : BaseModelController<User, UserViewModel>
    {
        private readonly IService<User> _userService;
        private readonly IMapper _mapper;

        public UsersController(
            IService<User> userService,
            IMapper mapper)
            : base(userService, mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }

    }
}
