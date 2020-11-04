using Programatica.Framework.Mvc.Adapters;

namespace Programatica.AspNetCore31AppSkeleton.Adapters
{
    public interface IAppPageAdapter : IPageAdapter
    {
        string AppVersion { get; }
    }
}
