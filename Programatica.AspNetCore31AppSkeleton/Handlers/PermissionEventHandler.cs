using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.Framework.Core.Adapter;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services.Handlers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.Handlers
{
    public class PermissionEventHandler : IEventHandler<UserRole>
    {
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IAuthUserAdapter _authUserAdapter;

        public PermissionEventHandler(
            IRepository<UserRole> userRoleRepository,
            IRepository<User> userRepository,
            IAuthUserAdapter authUserAdapter)
        {
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _authUserAdapter = authUserAdapter;
        }

        #region unused events

        public void OnAfterCreated(UserRole model)
        {
        }

        public void OnAfterDeleted(UserRole model)
        {
        }

        public void OnAfterDestroyed(UserRole model)
        {
        }

        public void OnAfterModified(UserRole model)
        {
        }

        public void OnBeforeCreating(UserRole model)
        {
        }

        public void OnBeforeDeleting(UserRole model)
        {
        }

        public void OnBeforeDestroying(UserRole model)
        {
        }

        public void OnBeforeInspecting(UserRole model)
        {
        }

        public void OnBeforeModifying(UserRole model)
        {
        }

        public Task OnAfterCreatedAsync(UserRole model)
        {
            return Task.CompletedTask;
        }

        public Task OnAfterModifiedAsync(UserRole model)
        {
            return Task.CompletedTask;
        }

        public Task OnBeforeDestroyingAsync(UserRole model)
        {
            return Task.CompletedTask;
        }

        public Task OnAfterDestroyedAsync(UserRole model)
        {
            return Task.CompletedTask;
        }

        public Task OnAfterDeletedAsync(UserRole model)
        {
            return Task.CompletedTask;
        }

        public Task OnBeforeInspectingAsync(UserRole model)
        {
            return Task.CompletedTask;
        }

        #endregion


        public async Task OnBeforeCreatingAsync(UserRole model)
        {
            if (await IsSameUserAndRole(model)) throw new Exception("The record already exists.");
            if (await IsSameForCurrentUser(model)) throw new Exception("Changing permissions for the current user is not allowed.");
        }

        public async Task OnBeforeModifyingAsync(UserRole model)
        {
            if (await IsSameUserAndRole(model)) throw new Exception("The record already exists.");
            if (await IsSameForCurrentUser(model)) throw new Exception("Changing permissions for the current user is not allowed.");
        }

        public async Task OnBeforeDeletingAsync(UserRole model)
        {
            if (await IsSameForCurrentUser(model)) throw new Exception("Changing permissions for the current user is not allowed.");
        }

        private async Task<bool> IsSameUserAndRole(UserRole model)
        {
            return (await _userRoleRepository.GetDataAsync())
                                      .Where(x => x.UserId == model.UserId &&
                                                  x.RoleId == model.RoleId &&
                                                  x.Id != model.Id)
                                      .FirstOrDefault() != null;
        }

        private async Task<bool> IsSameForCurrentUser(UserRole model)
        {
            var username = (await _userRepository.GetDataAsync(model.UserId)).Username;
            var authUser = _authUserAdapter.Name;
            return username.Equals(authUser);
        }

    }
}
