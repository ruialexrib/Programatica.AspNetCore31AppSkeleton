using Programatica.Framework.Data.Models;

namespace Programatica.AspNetCore31AppSkeleton.ViewModels
{
    public class UserViewModel : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
