using AutoMapper;
using EcoCheck.Dtos;
using EcoCheck.Dtos.CreateDtos;
using EcoCheck.Dtos.UpdateDtos;
using EcoCheck.Models;

namespace EcoCheck.Mappers
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
