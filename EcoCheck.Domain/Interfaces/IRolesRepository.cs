

using Microsoft.AspNetCore.Identity;

namespace EcoCheck.Domain.Interfaces
{
    public interface IRolesRepository
    {
        IQueryable<IdentityRole<int>> GetRoles();
        Task<IdentityRole<int>> GetRolesByNameAsync(string roleName);
        Task<IdentityResult> CreateRoleAsync(IdentityRole<int> role);
        Task<IdentityResult> DeleteRoleAsync(IdentityRole<int> role);
        
    }
}
