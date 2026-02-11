


using System.Threading.Tasks;
using EcoCheck.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EcoCheck.Infrastructure.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public RolesRepository(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }

        IQueryable<IdentityRole<int>> IRolesRepository.GetRoles()
        {
            var roles= _roleManager.Roles;

            return roles;
        }

        public async Task<IdentityRole<int>> GetRolesByNameAsync(string roleName)
        {
            var rol = await _roleManager.FindByNameAsync(roleName);

            return rol;
        }

        public async Task<IdentityResult> CreateRoleAsync(IdentityRole<int> role)
        {

            var identityResult = await _roleManager.CreateAsync(role);

            return identityResult;
        }

        
        public async Task<IdentityResult> DeleteRoleAsync(IdentityRole<int> role)
        {
            var result = await _roleManager.DeleteAsync(role);

            return result;
        }

        
    }
}
