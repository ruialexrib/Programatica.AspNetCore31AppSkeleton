using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.Framework.Core.Adapter;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services.Handlers;
using System;
using System.Linq;

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
            if (IsSameUserAndRole(model)) throw new Exception("The record already exists.");
            if (IsSameForCurrentUser(model)) throw new Exception("Changing permissions for the current user is not allowed.");
        }

        public void OnBeforeDeleting(UserRole model)
        {
            if (IsSameForCurrentUser(model)) throw new Exception("Changing permissions for the current user is not allowed.");
        }

        public void OnBeforeDestroying(UserRole model)
        {
        }

        public void OnBeforeInspecting(UserRole model)
        {
        }

        public void OnBeforeModifying(UserRole model)
        {
            if (IsSameUserAndRole(model)) throw new Exception("The record already exists.");
            if (IsSameForCurrentUser(model)) throw new Exception("Changing permissions for the current user is not allowed.");
        }

        private bool IsSameUserAndRole(UserRole model)
        {
            return _userRoleRepository.GetData()
                                      .Where(x => x.UserId == model.UserId &&
                                                  x.RoleId == model.RoleId &&
                                                  x.Id != model.Id)
                                      .FirstOrDefault() != null;
        }

        private bool IsSameForCurrentUser(UserRole model)
        {
            var username = _userRepository.GetData(model.UserId).Username;
            var authUser = _authUserAdapter.Name;
            return username.Equals(authUser);
        }
    }
}
