﻿using Programatica.Framework.Data.Models;

namespace Programatica.AspNetCore31AppSkeleton.Data.Models
{
    public class UserRole : BaseModel
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
