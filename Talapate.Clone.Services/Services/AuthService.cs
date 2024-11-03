using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites.Identity;
using Talabate.Clone.Core.Services.Contruct;

namespace Talapate.Clone.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateUserAsync(AppUser user, UserManager<AppUser> userManager)
        {
            //Generate Private Claims "Information Exchange"
            var AuthClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.DisplayName),
                new Claim(ClaimTypes.Email,user.Email),
            };
            //Get User Role
            var userRoles =await userManager.GetRolesAsync(user);
            //Add User Roles To AuthClaims 
            foreach (var role in userRoles)
            {
                AuthClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            // Generate authsecurity key using SymmetricSecurityKey From JWT
            var AuthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:AuthSecurityKey"]??string.Empty));
            // Generate registered Cliams
            var token = new JwtSecurityToken(
                audience: _configuration["JWT:ValidAudience"],
                issuer: _configuration["JWT:ValidIssure"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationInDayes"]??"0")),
                claims:AuthClaims,
                signingCredentials:new SigningCredentials(AuthKey, SecurityAlgorithms.HmacSha256Signature));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
