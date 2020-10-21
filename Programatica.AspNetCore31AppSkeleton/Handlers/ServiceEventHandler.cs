using Programatica.Framework.Data.Models;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services.Handlers;

namespace Programatica.AspNetCore31AppSkeleton.Handlers
{
    public class ServiceEventHandler<T> : IEventHandler<T>
                        where T : IModel
    {

        private readonly IRepository<T> _modelRepository;

        public ServiceEventHandler(IRepository<T> modelRepository)
        {
            _modelRepository = modelRepository;
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
        }

        public void OnBeforeDeleting(T model)
        {
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
            model.CreatedDate = current.CreatedDate;
            model.CreatedUser = current.CreatedUser;
        }
    }
}
