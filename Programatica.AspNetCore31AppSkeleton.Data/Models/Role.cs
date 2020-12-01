using Programatica.Framework.Data.Models;
using System.Collections.Generic;

namespace Programatica.AspNetCore31AppSkeleton.Data.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
    }
}
