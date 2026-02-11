
using AutoMapper;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using Microsoft.AspNetCore.Identity;

namespace EcoCheck.Application.Mappers
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole<int>, RolDto>();
            CreateMap<CreateRolDto, IdentityRole<int>>();
        }
    }
}
