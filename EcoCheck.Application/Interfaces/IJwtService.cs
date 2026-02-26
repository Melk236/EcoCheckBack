

using EcoCheck.Application.Dtos;
using EcoCheck.Domain.Entities;

namespace EcoCheck.Application.Interfaces
{
   public interface IJwtService
    {
        public string GenerateToken(ApplicationUser user,string rol);
        public Task<string> GenerateRefreshTokenAsync(int UserId);
        public Task<TokenResponseDto> RefreshAsync(string refreshToken);
        public Task LogOutAsync(string refreshToken);
    }
}
