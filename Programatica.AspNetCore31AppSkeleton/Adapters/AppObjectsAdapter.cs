using Programatica.Framework.Mvc.Infrastructure;

namespace Programatica.AspNetCore31AppSkeleton.Adapters
{
    public class AppObjectsAdapter : IAppObjectsAdapter
    {
        private string _grid_users;

        public string Grid_Users
        {
            get
            {
                if (string.IsNullOrEmpty(_grid_users))
                {
                    _grid_users = Razor.GenerateElementId("grid_users");
                }
                return _grid_users;
            }
        }

    }
}
