using AutoMapper;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Domain.Entities;

namespace EcoCheck.Application.Mappers
{
    public class MaterialProfile:Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDto>();
            CreateMap<CreateMaterialDto, Material>();
            CreateMap<UpdateMaterialDto, Material>();
        }
    }
}
