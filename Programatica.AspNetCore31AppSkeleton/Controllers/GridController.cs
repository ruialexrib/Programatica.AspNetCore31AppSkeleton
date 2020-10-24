using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Programatica.AspNetCore31AppSkeleton.Controllers.Base;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Services;
using System;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    [Authorize(Roles = "Administrators, Users")]
    public class GridController : BaseModelController<Dummy, DummyViewModel>
    {
        private readonly IService<Dummy> _dummyService;
        private readonly IMapper _mapper;

        public GridController(
            IService<Dummy> dummyService,
            IMapper mapper)
            : base(dummyService, mapper)
        {
            _dummyService = dummyService;
            _mapper = mapper;

            PageMessages.Add("Message from GridController Constructor");
            PageWarnings.Add("Warning from GridController Constructor");
            PageAlerts.Add("Alert from GridController Constructor");
        }
          
 
    }
}
