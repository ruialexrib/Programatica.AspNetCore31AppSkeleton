using Programatica.Framework.Data.Models;

namespace Programatica.AspNetCore31AppSkeleton.Data.Models
{
    public class RoleAction : BaseModel
    {
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
