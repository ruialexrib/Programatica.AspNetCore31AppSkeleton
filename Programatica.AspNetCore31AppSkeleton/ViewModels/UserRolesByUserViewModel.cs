using System.Collections.Generic;

namespace Programatica.AspNetCore31AppSkeleton.ViewModels
{
    public class UserRolesByUserViewModel
    {
        public List<UserRoleViewModel> ListOfUserRoleViewModel { get; set; }
        public int UserId { get; set; }

        public UserRolesByUserViewModel()
        {
            ListOfUserRoleViewModel = new List<UserRoleViewModel>();
        }
    }
}
