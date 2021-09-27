using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TaskBe.Services
{
    public class JwtService
    {
        private readonly string secret;
        private readonly string expDate;

        public JwtService(IConfiguration configuration)
        {
            secret = configuration.GetSection("JwtConfig").GetSection("secret").Value;
            expDate = configuration.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
            
           // var key = Encoding.ASCII.GetBytes(configuration.GetSection("JwtConfig").GetSection("secret").Value);
           // services.AddAuthentication(x =>
           // {
           //     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           //     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           // })
           //.AddJwtBearer(x =>
           //{
           //    x.TokenValidationParameters = new TokenValidationParameters
           //    {
           //        IssuerSigningKey = new SymmetricSecurityKey(key),
           //        ValidateIssuer = true,
           //        ValidateAudience = true,
           //        ValidIssuer = "http://localhost:44358",
           //        ValidAudience = "http://localhost:44358"
           //    };
           //});
        }

        public string GenerateToken(string name)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            tokenDescriptor.Audience = "https://localhost:44358";
            tokenDescriptor.Issuer = "https://localhost:44358";
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
