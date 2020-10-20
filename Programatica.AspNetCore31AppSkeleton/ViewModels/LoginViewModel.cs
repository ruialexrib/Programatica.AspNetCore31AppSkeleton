using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
