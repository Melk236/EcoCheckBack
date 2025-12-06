using AutoMapper;
using EcoCheck.Dtos;
using EcoCheck.Dtos.CreateDtos;
using EcoCheck.Dtos.UpdateDtos;
using EcoCheck.Models;

namespace EcoCheck.Mappers
{
    public class CertificacionProfile:Profile
    {
        public CertificacionProfile()
        {
            CreateMap<Certificacion,CertificacionDto>();
            CreateMap<CreateCertificacionDto, Certificacion>();
            CreateMap<UpdateCertificacionDto,Certificacion>();
        }
    }
}
