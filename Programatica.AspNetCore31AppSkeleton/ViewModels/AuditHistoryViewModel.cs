using Programatica.AspNetCore31AppSkeleton.ViewModels.Base;
using System.Collections.Generic;

namespace Programatica.AspNetCore31AppSkeleton.ViewModels
{
    public class AuditHistoryViewModel : BaseViewModel
    {
        public List<AuditViewModel> ListOfAuditViewModel { get; set; }

        public AuditHistoryViewModel()
        {
            ListOfAuditViewModel = new List<AuditViewModel>();
        }
    }

}
