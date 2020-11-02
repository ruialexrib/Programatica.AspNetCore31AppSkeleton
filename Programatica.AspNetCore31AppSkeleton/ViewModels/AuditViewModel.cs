using Programatica.Framework.Data.Models;

namespace Programatica.AspNetCore31AppSkeleton.ViewModels
{
    public class AuditViewModel :Audit
    {
        public int TrackedFieldsCount { get; set; }
    }
}
