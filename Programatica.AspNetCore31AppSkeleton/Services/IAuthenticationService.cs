using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.Services
{
    public interface IAuthenticationService
    {
        Task SignIn(HttpContext httpContext, string username, string password, bool isPersistent = false);
        Task SignOut(HttpContext httpContext);
    }
}
