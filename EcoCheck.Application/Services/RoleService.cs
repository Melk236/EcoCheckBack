



using AutoMapper;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Interfaces;
using EcoCheck.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace EcoCheck.Application.Services
{
    public class RoleService:IRoleService
    {
        private readonly IRolesRepository _rolRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleService> _logger;

        public RoleService(IRolesRepository rolRepository,IMapper mapper,ILogger<RoleService> logger)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<RolDto>> GetAllRoles()
        {
            var roles = await _rolRepository.GetRoles().ToListAsync();

            return _mapper.Map<List<RolDto>>(roles);
        }

        public async Task<RolDto> GetRoleByName(string roleName){

            if (string.IsNullOrEmpty(roleName)) throw new BadRequestException("El roleName está vacío");
            
            var rol=await _rolRepository.GetRolesByNameAsync(roleName);

            if(rol==null) throw new NotFoundException("No se ha encontrado el rol con con nombre "+roleName);

            return _mapper.Map<RolDto>(rol);
        }
        public async Task<RolDto> CreateRoleAsync(CreateRolDto role)
        {
            if(string.IsNullOrEmpty(role.Name)) throw new BadRequestException("El cambo nombre del rol está vacío");

            var rol=_mapper.Map<IdentityRole<int>>(role);
            var result = await _rolRepository.CreateRoleAsync(rol);

            if (!result.Succeeded)
            {
                var errors=result.Errors.Select(x=>x.Description).ToList();

                _logger.LogError(string.Join(", ", errors));
                throw new Exception("");
            }

            return _mapper.Map<RolDto>(rol);
        }

        public async Task DeleteRoleAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName)) throw new BadRequestException("El campo roleName está vacío");

            var rol = await _rolRepository.GetRolesByNameAsync(roleName);

            if(rol==null) throw new NotFoundException("No se ha encontrado el rol con nombre "+rol);

            var result=await _rolRepository.DeleteRoleAsync(rol);

            if (!result.Succeeded)
            {
                var errors=result.Errors.Select(x=>x.Description).ToList();

                _logger.LogError(string.Join(", ", errors));
                throw new Exception("");
            }

        }

        
    }
}
