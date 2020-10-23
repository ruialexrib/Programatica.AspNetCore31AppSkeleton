using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.Framework.Core.Adapter;
using Programatica.Framework.Services;
using Syncfusion.EJ2.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDateTimeAdapter _dateTimeAdapter;
        private readonly IService<User> _userService;
        private readonly IService<Role> _roleService;
        private readonly IService<UserRole> _userRoleService;

        public AuthenticationService(
            IDateTimeAdapter dateTimeAdapter,
            IService<User> userService,
            IService<Role> roleService,
            IService<UserRole> userRoleService)
        {
            _dateTimeAdapter = dateTimeAdapter;
            _userService = userService;
            _roleService = roleService;
            _userRoleService = userRoleService;
        }

        public async Task SignIn(HttpContext httpContext, string username, string password, bool isPersistent = false)
        {
            if (GetByUsernameAndPassword(username, password) != null)
            {
                var claims = GetUserPrincipalClaims(username, password);
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
            else
            {
                throw new AuthenticationException("Wrong username or password");
            }
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
            var u = _userService.Get().Where(x => x.Username.Equals(user)).FirstOrDefault();
            var userRoles = _userRoleService.Get().Where(x => x.UserId == u.Id);

            claims.AddRange(from UserRole ur in userRoles
                            let role = _roleService.Get().Where(x => x.Id == ur.RoleId).FirstOrDefault()
                            select new Claim(ClaimTypes.Role, role.Name));
            return claims;
        }

        private User GetByUsernameAndPassword(string username, string password)
        {
            var user = _userService.Get()
                                    .Where(x => x.Username.Equals(username) && x.Password.Equals(password))
                                    .FirstOrDefault();
            return user;
        }
    }
}
