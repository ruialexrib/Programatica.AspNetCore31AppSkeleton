﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.Framework.Core.Adapter;
using Programatica.Framework.Mvc.Authentication;
using Programatica.Framework.Mvc.Options;
using Programatica.Framework.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Programatica.AspNetCore31AppSkeleton.Services
{
    public class AuthenticationUtility : IAuthenticationUtility
    {
        private readonly IDateTimeAdapter _dateTimeAdapter;
        private readonly IService<User> _userService;
        private readonly IService<Role> _roleService;
        private readonly IService<UserRole> _userRoleService;
        private readonly ILogger<AuthenticationUtility> _logger;
        private readonly ClaimBasedAuthAdapterOptions _options;

        public AuthenticationUtility(
            IDateTimeAdapter dateTimeAdapter,
            IService<User> userService,
            IService<Role> roleService,
            IService<UserRole> userRoleService,
            ILogger<AuthenticationUtility> logger,
            IOptions<ClaimBasedAuthAdapterOptions> options)
        {
            _dateTimeAdapter = dateTimeAdapter;
            _userService = userService;
            _roleService = roleService;
            _userRoleService = userRoleService;
            _logger = logger;
            _options = options.Value;
        }

        public IEnumerable<Claim> GetUserPrincipalClaims(string user, string password)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(_options.UserNameFieldName, user));
            claims.Add(new Claim(_options.PasswordFieldName, password));
            claims.Add(new Claim(_options.LastLoginDateTimeFieldName, _dateTimeAdapter.UtcNow.ToString()));
            claims.AddRange(GetUserRoleClaims(user));
            return claims;
        }

        public IEnumerable<Claim> GetUserRoleClaims(string user)
        {
            List<Claim> claims = new List<Claim>();
            var u = _userService.Get()
                                .Where(x => x.Username.Equals(user))
                                .FirstOrDefault();

            var userRoles = _userRoleService.Get()
                                            .Where(x => x.UserId == u.Id);

            claims.AddRange(from UserRole ur in userRoles
                            let role = _roleService.Get()
                                                   .Where(x => x.Id == ur.RoleId)
                                                   .FirstOrDefault()
                            select new Claim(ClaimTypes.Role, role.Name));
            return claims;
        }

        public bool AuthByUsernameAndPassword(string username, string password)
        {
            var user = _userService.Get()
                                   .Where(x => x.Username.Equals(username) && x.Password.Equals(password))
                                   .FirstOrDefault();
            return user != null;
        }
    }
}
