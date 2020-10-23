using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels.Base;
using Programatica.Framework.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.ViewModels
{
    public class PermissionViewModel : BaseViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public List<User> ListOfUsers { get; set; }
        public int SelectedUserId { get; set; }
        public List<Role> ListOfRoles { get; set; }
        public int SelectedRoleId { get; set; }
    }
}
