

using EcoCheck.Domain.Entities;
using EcoCheck.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EcoCheck.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckUserAsync(ApplicationUser user, string password)
        {
           
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> CreateUserAsync(ApplicationUser user, string password)
        {

            var result= await _userManager.CreateAsync(user, password);

            if (result.Succeeded) return true;

            return false;
            
            
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string user)
        {
            var usuario = await _userManager.FindByNameAsync(user);
            
            return usuario;
        }
    }
}
