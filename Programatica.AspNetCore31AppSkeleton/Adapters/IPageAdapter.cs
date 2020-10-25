using Programatica.AspNetCore31AppSkeleton.ViewModels;
using System.Collections.Generic;

namespace Programatica.AspNetCore31AppSkeleton.Adapters
{
    public interface IPageAdapter
    {
        string ConnectionString { get; }

        List<string> PageMessages { get;  }
        List<string> PageWarnings { get; }
        List<string> PageAlerts { get; }

        string ControllerName { get; }
        string ActionName { get; }
    }
}
