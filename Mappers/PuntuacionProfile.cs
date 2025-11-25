using AutoMapper;
using EcoCheck.Dtos;
using EcoCheck.Dtos.CreateDtos;
using EcoCheck.Dtos.UpdateDtos;
using EcoCheck.Models;

namespace EcoCheck.Mappers
{
    public class PuntuacionProfile:Profile
    {
        public PuntuacionProfile()
        {
            CreateMap<Puntuacion,PuntuacionDto>();
            CreateMap<CreateProductoDto, Puntuacion>();
            CreateMap<UpdateProductoDto, Puntuacion>();
        }
    }
}
