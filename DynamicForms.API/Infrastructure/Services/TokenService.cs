using Infrastructure.Data.Identity.Models;
using Infrastructure.Helpers.Models;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly IOptions<JwtSettings> _jwt;

        public TokenService(UserManager<User> userManager, IOptions<JwtSettings> jwt)
        {
            this._userManager = userManager;
            this._jwt = jwt;
        }

        public async Task<string> CreateToken(string userEmail)
        {
            var identityUser = await _userManager.FindByEmailAsync(userEmail);

            var issuer = _jwt.Value.Issuer;
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _jwt.Value.Key));

            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Email, identityUser.Email),
                    new Claim(ClaimTypes.Name, identityUser.UserName),
            };

            var roles = await _userManager.GetRolesAsync(identityUser);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(
                issuer,
                issuer,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
