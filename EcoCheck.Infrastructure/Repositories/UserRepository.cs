

using EcoCheck.Domain.Entities;
using EcoCheck.Domain.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcoCheck.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserRepository(UserManager<ApplicationUser> userMasnager)
        {
           _userManager = userMasnager;

        }

        public  IQueryable<ApplicationUser> GetAllUsers()
        {
            return _userManager.Users.AsNoTracking();
        }

        public async Task<ApplicationUser> GetById(int id)
        {
            var usuario = await _userManager.FindByIdAsync(id.ToString());

            return usuario;
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            
            await _userManager.UpdateAsync(user);
            
          
        }
        

        public async Task DeleteUser(ApplicationUser user)
        {
            await _userManager.DeleteAsync(user);
        }

        
    }
}
