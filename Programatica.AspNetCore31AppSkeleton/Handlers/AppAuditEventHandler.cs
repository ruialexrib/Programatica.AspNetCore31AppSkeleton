//using Programatica.Framework.Core.Adapter;
//using Programatica.Framework.Data.Extensions;
//using Programatica.Framework.Data.Models;
//using Programatica.Framework.Data.Repository;
//using Programatica.Framework.Services;
//using Programatica.Framework.Services.Handlers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Programatica.AspNetCore31AppSkeleton.Handlers
//{
//    public class AppAuditEventHandler<T> : IEventHandler<T>
//                where T : IModel
//    {

//        private readonly IRepository<Audit> _auditRepository;
//        private readonly IDateTimeAdapter _dateTimeAdapter;
//        private readonly IAuthUserAdapter _authUserAdapter;
//        private readonly IRepository<T> _modelRepository;
//        private readonly IService<TrackChange> _trackChangesService;

//        public AppAuditEventHandler(
//            IRepository<Audit> auditRepository,
//            IDateTimeAdapter dateTimeAdapter,
//            IAuthUserAdapter authUserAdapter,
//            IRepository<T> modelRepository,
//            IService<TrackChange> trackChangesService)
//        {
//            _auditRepository = auditRepository;
//            _dateTimeAdapter = dateTimeAdapter;
//            _authUserAdapter = authUserAdapter;
//            _modelRepository = modelRepository;
//            _trackChangesService = trackChangesService;
//        }

//        public void OnAfterCreated(T model)
//        {
//            var audit = CreateAudit(model, "Create");
//            CreateTrackChanges(false, model, audit.Id);
//        }

//        public void OnAfterDeleted(T model)
//        {
//            CreateAudit(model, "Deleted");
//        }

//        public void OnAfterDestroyed(T model)
//        { }

//        public void OnBeforeInspecting(T model)
//        {
//            CreateAudit(model, "Inspect");
//        }

//        public void OnAfterModified(T model)
//        { }

//        public void OnBeforeCreating(T model)
//        { }

//        public void OnBeforeDeleting(T model)
//        { }

//        public void OnBeforeDestroying(T model)
//        {
//            var audit = CreateAudit(model, "Destroy");
//            CreateTrackChanges(true, model, audit.Id);
//        }

//        public void OnBeforeModifying(T model)
//        {
//            var audit = CreateAudit(model, "Modify");
//            CreateTrackChanges(true, model, audit.Id);
//        }

//        private Audit CreateAudit(T model, string functionTypeDefinitionProvider)
//        {
//            var audit = new Audit
//            {
//                ContentSystemId = model.SystemId,
//                ContentId = model.Id,
//                ContentType = model.GetProxyType().Name,
//                ContentFunction = functionTypeDefinitionProvider,

//                CreatedDate = _dateTimeAdapter.UtcNow,
//                CreatedUser = _authUserAdapter.Name,

//                IsSystem = true
//            };
//            _auditRepository.Insert(audit);
//            return audit;
//        }

//        private List<Variance> CreateTrackChanges(bool isModify, IModel model, int auditId)
//        {
//            var old = Activator.CreateInstance<T>();
//            old.SystemId = Guid.Empty;

//            if (isModify)
//            {
//                old = _modelRepository.GetData(model.Id);
//            }
//            var changes = model.TrackChanges(old);

//            foreach (var change in changes)
//            {
//                _trackChangesService.Create(new TrackChange
//                {
//                    AuditId = auditId,
//                    FieldName = change.Prop,
//                    OldValue = change.valB.ToString(),
//                    NewValue = change.valA.ToString()
//                });
//            }
//            return changes;
//        }


//    }
//}
