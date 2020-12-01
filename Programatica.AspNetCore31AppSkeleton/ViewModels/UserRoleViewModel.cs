using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels.Base;
using System.Collections.Generic;

namespace Programatica.AspNetCore31AppSkeleton.ViewModels
{
    public class UserRoleViewModel : BaseViewModel
    {
        public int UserId{ get; set; }
        public int RoleId { get; set; }

        public string UserName { get; set; }
        public string RoleName { get; set; }

        public List<User> ListOfUsers { get; set; }
        public int SelectedUserId { get; set; }
        public List<Role> ListOfRoles { get; set; }
        public int SelectedRoleId { get; set; }
    }
}
