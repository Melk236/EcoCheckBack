using AutoMapper;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Domain.Entities;

namespace EcoCheck.Application.Mappers
{
    public class PuntuacionProfile:Profile
    {
        public PuntuacionProfile()
        {
            CreateMap<Puntuacion,PuntuacionDto>();
            CreateMap<CreatePuntuacionDto, Puntuacion>();
            CreateMap<UpdatePuntuacionDto, Puntuacion>();
        }
    }
}
