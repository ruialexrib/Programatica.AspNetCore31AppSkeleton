using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Mvc.Controllers;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class AuditsController : BaseController
    {
        private readonly IRepository<Audit> _auditRepository;
        private readonly IRepository<TrackChange> _trackChangesRepository;
        protected readonly IMapper _mapper;

        public AuditsController(
            IRepository<Audit> auditRepository,
            IRepository<TrackChange> trackChangesRepository,
            IMapper mapper)
        {
            _auditRepository = auditRepository;
            _trackChangesRepository = trackChangesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AuditHistory(string systemid)
        {
            var trackchanges = await _trackChangesRepository.GetDataAsync();
            var vm = (await _auditRepository.GetDataAsync())
                                     .Where(x => x.ContentSystemId == Guid.Parse(systemid))
                                     .Select(x => new AuditViewModel
                                     {
                                         Id = x.Id,
                                         SystemId = x.SystemId,
                                         ContentSystemId = x.ContentSystemId,
                                         ContentFunction = x.ContentFunction,
                                         ContentType = x.ContentType,
                                         CreatedDate = x.CreatedDate,
                                         CreatedUser = x.CreatedUser,
                                         TrackedFieldsCount = trackchanges
                                                                .Where(z => z.AuditId == x.Id)
                                                                .Count()
                                     })
                                     .ToList();
            return PartialView("_AuditHistory", vm);
        }

        [HttpGet]
        public async Task<IActionResult> TrackChanges(int auditId)
        {
            var vm = (await _trackChangesRepository.GetDataAsync())
                                            .Where(x => x.AuditId == auditId)
                                            .ToList();
            return PartialView("_TrackChanges", vm);
        }
    }
}
