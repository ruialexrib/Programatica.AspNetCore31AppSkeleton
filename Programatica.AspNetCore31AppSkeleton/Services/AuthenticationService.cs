using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Programatica.Framework.Core.Adapter;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDateTimeAdapter _dateTimeAdapter;

        public AuthenticationService(IDateTimeAdapter dateTimeAdapter)
        {
            _dateTimeAdapter = dateTimeAdapter;
        }

        public async Task SignIn(HttpContext httpContext, string username, string password, bool isPersistent = false)
        {
            var claims = GetUserPrincipalClaims(username, password);
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public async Task SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> GetUserPrincipalClaims(string user, string password)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim("AuthenticatedUserName", user));
            claims.Add(new Claim("AuthenticatedUserPassword", password));
            claims.Add(new Claim("AuthenticatedUserLastLoginDateTime", _dateTimeAdapter.UtcNow.ToString()));
            claims.AddRange(GetUserRoleClaims(user));
            return claims;
        }

        private IEnumerable<Claim> GetUserRoleClaims(string user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "User"));
            if (user.Equals("admin"))
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            return claims;
        }
    }
}
