
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Entities;
using EcoCheck.Domain.Exceptions;
using EcoCheck.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace EcoCheck.Application.Services
{
    public class JwtService:IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenRepository _repository;
        private readonly IUserRepository _userRepository;
        public JwtService(IConfiguration configuration,IRefreshTokenRepository repository,IUserRepository userRepository)
        {
            _configuration = configuration;
            _repository = repository;
            _userRepository = userRepository;
        }

        

        public string GenerateToken(ApplicationUser user,string rol)
        {
            var claims = new List<Claim>
            {
             new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
             new Claim(ClaimTypes.Name,user.UserName),
             new Claim(ClaimTypes.Role,rol)
            };
            
            //La clave secreta se convierte a bytes
            var keyBytes = Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt")["Key"]);
            var creds=new SigningCredentials(new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: _configuration.GetSection("Jwt")["Issuer"],
            audience: _configuration.GetSection("Jwt")["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration.GetSection("Jwt")["ExpiryInMinutes"])),  // exp
            signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }

        public async Task<string> GenerateRefreshTokenAsync(int UserId)
        {
            if (UserId<=0) throw new BadRequestException("El id del usuario es null");

            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false,
                UserId = UserId

            };

            await _repository.CreateRefreshToken(refreshToken);

            return refreshToken.Token;
        }

        public async Task<TokenResponseDto> RefreshAsync(string token)
        {
            var refreshToken = await _repository.GetRefreshTokenByUserId(token);
            //Comprobamos que el refresh token es válido
            if (refreshToken is null || refreshToken.IsRevoked || refreshToken.ExpiresAt.CompareTo(DateTime.UtcNow) < 0) throw new UnauthorizedException("Operación inválida,vuelva a iniciar sesión");

            //Creamos un nuevo refreshToken para rotación
            refreshToken.IsRevoked = true;

            //Creamos un nuevo refreshToken y token válidos
            var newRefreshToken= await GenerateRefreshTokenAsync(refreshToken.UserId);
            var usuario = await _userRepository.GetById(refreshToken.UserId);
            var rol = await _userRepository.GetRolesUserAsync(usuario);
            var newToken = GenerateToken(refreshToken.User,rol);

            var responseToken = new TokenResponseDto
            {
                Token = newToken,
                RefreshToken = newRefreshToken
            };

            return responseToken;
        }
    }
}
