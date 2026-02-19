using EcoCheck.Domain.Entities;
using EcoCheck.Domain.Interfaces;
using EcoCheck.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCheck.Infrastructure.Repositories
{

    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly DbSet<RefreshToken> _dbSet;
        private readonly AppDbContext _context;

        public RefreshTokenRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<RefreshToken>();
        }
        public async Task CreateRefreshToken(RefreshToken token)
        {
            _dbSet.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetRefreshTokenByUserId(string token)
        {
           var refreshToken=await _dbSet.FirstOrDefaultAsync(x=>x.Token == token);

            return refreshToken;
        }
    }
}
