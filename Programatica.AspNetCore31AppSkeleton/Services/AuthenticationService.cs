using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task SignIn(HttpContext httpContext, string username, bool isPersistent = false)
        {
            ClaimsIdentity identity = new ClaimsIdentity(GetUserClaims(username), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public async Task SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> GetUserClaims(string user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user));
            claims.Add(new Claim(ClaimTypes.Name, user));
            claims.Add(new Claim(ClaimTypes.Email, user));
            claims.AddRange(this.GetUserRoleClaims(user));
            return claims;
        }

        private IEnumerable<Claim> GetUserRoleClaims(string user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, "admin"));
            return claims;
        }
    }
}
