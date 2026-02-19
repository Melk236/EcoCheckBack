using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRoles();

            return Ok(roles);
        }

        [HttpGet("{roleName}")]
        [Authorize]
        public async Task<IActionResult> GetRolByName(string roleName)
        {
            var rol = await _roleService.GetRoleByName(roleName);

            return Ok(rol);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRole([FromBody] CreateRolDto dto) 
        {
            var rol = await _roleService.CreateRoleAsync(dto);
            var url=$"/api/roles/{dto.Name}";

            return Created(url, rol);
        }
        [HttpDelete("{roleName}")]
        [Authorize]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            await _roleService.DeleteRoleAsync(roleName);

            return NoContent();
        }
    }

}
