using Programatica.Framework.Data.Models;
using System.Collections.Generic;

namespace Programatica.AspNetCore31AppSkeleton.Data.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
    }
}
