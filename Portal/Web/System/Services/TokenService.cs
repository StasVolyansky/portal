using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using static System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace Portal.Web.System.Services
{
    public class TokenService
    {
        private readonly IConfigurationRoot config;

        public TokenService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            config = builder.Build();
        }

        public string CreateToken(string username) =>
            new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                issuer: config["Tokens:Issuer"],
                audience: config["Tokens:Audience"],
                claims: new[]
                {
                    new Claim(Sub, username),
                    new Claim(Jti, Guid.NewGuid().ToString()),
                    new Claim(UniqueName, username),
                },
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokens:Key"])),
                    SecurityAlgorithms.HmacSha256),
                expires: DateTime.Now.AddMinutes(double.Parse(config["Tokens:Expires"]))
            ));
    }
}