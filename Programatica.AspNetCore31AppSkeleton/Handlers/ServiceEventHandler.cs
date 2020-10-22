using Programatica.Framework.Core.Adapter;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services.Handlers;

namespace Programatica.AspNetCore31AppSkeleton.Handlers
{
    public class ServiceEventHandler<T> : IEventHandler<T>
                        where T : IModel
    {

        private readonly IRepository<T> _modelRepository;
        private readonly IDateTimeAdapter _dateTimeAdapter;
        private readonly IAuthUserAdapter _authUserAdapter;

        public ServiceEventHandler(IRepository<T> modelRepository, IDateTimeAdapter dateTimeAdapter, IAuthUserAdapter authUserAdapter)
        {
            _modelRepository = modelRepository;
            _dateTimeAdapter = dateTimeAdapter;
            _authUserAdapter = authUserAdapter;
        }

        public void OnAfterCreated(T model)
        {
        }

        public void OnAfterDeleted(T model)
        {
        }

        public void OnAfterDestroyed(T model)
        {
        }

        public void OnAfterModified(T model)
        {
        }

        public void OnBeforeCreating(T model)
        {
            model.LastModifiedDate = _dateTimeAdapter.UtcNow;
            model.LastModifiedUser = _authUserAdapter.Name;
        }

        public void OnBeforeDeleting(T model)
        {
            if (model.IsSystem)
            {
                throw new System.Exception("IModel system objects cant be deleted.");
            }
        }

        public void OnBeforeDestroying(T model)
        {
        }

        public void OnBeforeInspecting(T model)
        {
        }

        public void OnBeforeModifying(T model)
        {
            var current = _modelRepository.GetData(model.Id);
            model.SystemId = current.SystemId;
            model.IsSystem = current.IsSystem;
            model.CreatedDate = current.CreatedDate;
            model.CreatedUser = current.CreatedUser;
        }
    }
}
