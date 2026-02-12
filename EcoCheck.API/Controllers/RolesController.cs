using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController:ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRoles();

            return Ok(roles);
        }

        [HttpGet("{roleName}")]
        public async Task<IActionResult> GetRolByName(string roleName)
        {
            var rol = await _roleService.GetRoleByName(roleName);

            return Ok(rol);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRolDto dto) 
        {
            var rol = await _roleService.CreateRoleAsync(dto);
            var url=$"/api/roles/{dto.Name}";

            return Created(url, rol);
        }
        [HttpDelete("{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            await _roleService.DeleteRoleAsync(roleName);

            return NoContent();
        }
    }

}
