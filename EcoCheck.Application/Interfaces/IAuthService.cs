

using EcoCheck.Application.Dtos;
using EcoCheck.Domain.Entities;

namespace EcoCheck.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<ApplicationUser> CheckUser(LoginDto dto);
        public Task<ApplicationUser> CreateUser(LoginDto dto);
        public Task AssignRoleToUserAsync(ApplicationUser user, string role);
    }
}
