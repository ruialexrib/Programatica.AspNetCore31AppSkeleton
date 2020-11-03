using Programatica.Framework.Mvc.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.Adapters
{
    public interface IAppPageAdapter : IPageAdapter
    {
        string AppVersion { get; }
    }
}
