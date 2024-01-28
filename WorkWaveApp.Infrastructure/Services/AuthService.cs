using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Entities;

namespace WorkWaveApp.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            var issuer = _configuration["JWTSettings:Issuer"];
            var audience = _configuration["JWTSettings:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["JWTSettings:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("id", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("jti",  Guid.NewGuid().ToString().Replace("-","")),
             }),
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JWTSettings:Expiration"])),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials

                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }

        public string ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWTSettings:Key"]);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
            var jti = jwtToken.Claims.First(x => x.Type == "jti").Value;

            return token;
        }
    }
}
