using AutoMapper;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Domain.Entities;

namespace EcoCheck.Application.Mappers
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
