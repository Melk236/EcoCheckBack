
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;

namespace EcoCheck.Application.Interfaces
{
    public interface IRoleService
    {
        Task<List<RolDto>> GetAllRoles();
        Task<RolDto> GetRoleByName(string roleName);
        Task<RolDto> CreateRoleAsync(CreateRolDto role);
        Task DeleteRoleAsync(string roleName); 
    }
}
