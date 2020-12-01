using Programatica.Framework.Core.Adapter;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services.Handlers;
using System.Threading.Tasks;

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

        #region unused events

        public Task OnAfterCreatedAsync(T model)
        {
            return Task.CompletedTask;
        }

        public Task OnAfterDeletedAsync(T model)
        {
            return Task.CompletedTask;
        }

        public Task OnAfterDestroyedAsync(T model)
        {
            return Task.CompletedTask;
        }

        public Task OnAfterModifiedAsync(T model)
        {
            return Task.CompletedTask;
        }

        public Task OnBeforeDestroyingAsync(T model)
        {
            return Task.CompletedTask;
        }

        public Task OnBeforeInspectingAsync(T model)
        {
            return Task.CompletedTask;
        }

        #endregion

        public Task OnBeforeCreatingAsync(T model)
        {
            model.LastModifiedDate = _dateTimeAdapter.UtcNow;
            model.LastModifiedUser = _authUserAdapter.Name;
            return Task.CompletedTask;
        }

        public Task OnBeforeDeletingAsync(T model)
        {
            if (model.IsSystem)
            {
                throw new System.Exception("IModel system objects cant be deleted.");
            }
            return Task.CompletedTask;
        }

        public async Task OnBeforeModifyingAsync(T model)
        {
            var current =await _modelRepository.GetDataAsync(model.Id);
            model.SystemId = current.SystemId;
            model.IsSystem = current.IsSystem;
            model.CreatedDate = current.CreatedDate;
            model.CreatedUser = current.CreatedUser;
        }

    }
}
