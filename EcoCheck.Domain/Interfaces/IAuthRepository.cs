
using EcoCheck.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace EcoCheck.Domain.Interfaces
{
    public interface IAuthRepository
    {  
        Task<bool> CreateUserAsync(ApplicationUser user, string password);
        Task<bool> CheckUserAsync(ApplicationUser user,string password);
        Task<ApplicationUser> GetUserByNameAsync(string user);
        Task<IdentityResult> AssignRoleToUser(ApplicationUser user,string role);
        

    }
}
