using AutoMapper;
using EcoCheck.Dtos;
using EcoCheck.Dtos.CreateDtos;
using EcoCheck.Dtos.UpdateDtos;
using EcoCheck.Models;

namespace EcoCheck.Mappers
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
