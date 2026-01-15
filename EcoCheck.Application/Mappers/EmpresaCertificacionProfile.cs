using AutoMapper;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Domain.Entities;

namespace EcoCheck.Application.Mappers
{
    public class EmpresaCertificacionProfile:Profile
    {
        public EmpresaCertificacionProfile()
        {
            CreateMap<EmpresaCertificacion, EmpresaCertificacionDto>();
            CreateMap<CreateEmpresaCertificacionDto, EmpresaCertificacion>();
            CreateMap<UpdateEmpresaCertificacionDto, EmpresaCertificacion>();
        }
    }
}
