using Cradle.Domain.Entities.Account;
using Cradle.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Cradle.Application.Contracts.Infrastructure;

namespace Cradle.Infrastructure
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public TokenService(IConfiguration config,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }


        public async Task<string> GenerateToken(ApplicationUser user, Tenant tenant = null)
        {
            return GenerateEncryptedToken(GetSigninCredentials(), await GetClaimsAsync(user));
        }

        public string GetRefreshToken()
        {
            return null;
        }


        private static string GenerateEncryptedToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: signingCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var encryptedToken = tokenHandler.WriteToken(token);
            return encryptedToken;

        }

        private SigningCredentials GetSigninCredentials()
        {
            var secret = Encoding.UTF8.GetBytes(_config["Token:Key"]);
            return new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);
        }

        private async Task<IEnumerable<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            var permissionClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
                var currentRole = await _roleManager.FindByNameAsync(role);
                var allPermissionsForCurrentRole = await _roleManager.GetClaimsAsync(currentRole);
                permissionClaims.AddRange(allPermissionsForCurrentRole);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Name, user.FirstName),
            }.Union(userClaims)
            .Union(roleClaims)
            .Union(permissionClaims);
            return claims;
        }
    }
}
