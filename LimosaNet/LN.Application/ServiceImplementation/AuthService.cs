using LN.Contracts.Service;
using System.Text;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LN.Core.Entities;
using Microsoft.IdentityModel.Tokens;
using LN.Contracts.Models;

namespace LN.Application.ServiceImplementation
{
    public class AuthService : IAuthService
    {


        public AuthService()
        { }

        /// <inheritdoc/>
        public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        /// <summary>
        /// Verifies that the hash of the given text matches the provided hash
        /// </summary>
        /// <param name="text">The text to verify.</param>
        /// <param name="hash">The previously-hashed password.</param>
        /// <returns></returns>
        public bool Verify(string text, string hash) => BCrypt.Net.BCrypt.Verify(text, hash);

        /// <inheritdoc/>
        public string GenerateToken(string userLogin)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userLogin) };

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
            
        }
    }
}
