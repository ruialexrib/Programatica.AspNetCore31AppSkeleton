using Programatica.Framework.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Programatica.AspNetCore31AppSkeleton.Data.Models
{
    public class Permission : BaseModel
    {
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
