using AutoMapper;
using EcoCheck.Dtos;
using EcoCheck.Dtos.CreateDtos;
using EcoCheck.Dtos.UpdateDtos;
using EcoCheck.Models;

namespace EcoCheck.Mappers
{
    public class MarcaProfile:Profile
    {
        public MarcaProfile() {
            CreateMap<Marca,MarcaDto>();
            CreateMap<CreateMarcaDto, Marca>();
            CreateMap<UpdateMarcaDto, Marca>();
        }
    }
}
