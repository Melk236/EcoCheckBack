

using EcoCheck.Domain.Entities;
using EcoCheck.Domain.Interfaces;
using EcoCheck.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoCheck.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<ApplicationUser> _dbSet;
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _dbSet = context.Set<ApplicationUser>();
            _context = context;

        }

        public  IQueryable<ApplicationUser> GetAllUsers()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<ApplicationUser> GetById(int id)
        {
            var usuario= await _dbSet.FindAsync(id);

            return usuario;
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            _dbSet.Update(user);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteUser(ApplicationUser user)
        {
            

            _dbSet.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
