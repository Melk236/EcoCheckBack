
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EcoCheck.Application.Services
{
    public class JwtService:IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
             new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
             new Claim(ClaimTypes.Name,user.UserName)
            };
            
            //La clave secreta se convierte a 
            var keyBytes = Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt")["Key"]);
            var creds=new SigningCredentials(new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: _configuration.GetSection("Jwt")["Issuer"],
            audience: _configuration.GetSection("Jwt")["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),  // exp
            signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}
