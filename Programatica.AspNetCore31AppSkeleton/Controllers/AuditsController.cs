using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Mvc.Controllers;

namespace Programatica.AspNetCore31AppSkeleton.Controllers
{
    public class AuditsController : BaseController
    {
        private readonly IRepository<Audit> _auditRepository;

        public AuditsController(IRepository<Audit> auditRepository)
        {
            _auditRepository = auditRepository;
        }

        [HttpGet]
        public IActionResult ModelAudit(string systemid)
        {
            var vm = _auditRepository.GetData()
                                     .Where(x => x.ContentSystemId == Guid.Parse(systemid))
                                     .ToList();
            return PartialView("_ModelAudit", vm);
        }
    }
}
