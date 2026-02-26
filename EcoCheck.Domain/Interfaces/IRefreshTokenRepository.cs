
using EcoCheck.Domain.Entities;

namespace EcoCheck.Domain.Interfaces
{
    public interface IRefreshTokenRepository
    {
        public Task CreateRefreshToken(RefreshToken token);
        public Task<RefreshToken> GetRefreshToken(string refreshToken);
        public Task UpdateRefreshTokenAsync(RefreshToken token);
    }
}
