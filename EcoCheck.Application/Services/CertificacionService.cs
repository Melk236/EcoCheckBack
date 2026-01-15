using AutoMapper;
using EcoCheck.Infrastructure.Data;
using EcoCheck.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using EcoCheck.Domain.Exceptions;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Domain.Entities;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Interfaces;
namespace EcoCheck.Application.Services
{
    public class CertificacionService:ICertificacionService
    {
       
        private readonly IRepository<Certificacion> _repository;
        private readonly IMapper _mapper;
        public CertificacionService(AppDbContext context,IMapper mapper,IRepository<Certificacion> repository)
        {   
          
            _repository = repository;
            _mapper = mapper;
        }

            
        public async Task<List<CertificacionDto>> GetAllCertificaciones()
        {

            var certificaciones = await _repository.GetAll().ToListAsync();

            return _mapper.Map<List<CertificacionDto>>(certificaciones);
        }

        public async Task<CertificacionDto> GetCertificacionById(int id)
        {
            var certificacion=await _repository.GetById(id);

            if (certificacion==null)
            {
                throw new NotFoundException("No se ha encontrado la certificación con el id " + id);
            }

            return _mapper.Map<CertificacionDto>(certificacion);
        } 

        public async Task<List<CertificacionDto>> CreateCerticacion(IEnumerable<CreateCertificacionDto> dto)
        {
            if (dto==null)
            {
                throw new BadRequestException("Certificaciones vacías");
            }
            foreach (var item in dto) {
                if (String.IsNullOrEmpty(item.Name))
                {
                    throw new BadRequestException("Uno o más campos de la certifcación están vacíos");
                }


            }   
            

            var certificaciones=_mapper.Map<List<Certificacion>>(dto);

            

            await _repository.CreateRange(certificaciones);

            return _mapper.Map<List<CertificacionDto>>(certificaciones);
        }

        public async Task DeleteCertificacion(int id)
        {
            var certificacion = await _repository.GetById(id);

            if (certificacion==null)
            {
                throw new NotFoundException("No se ha encontrado la certificación con el id "+id);
            }


            await _repository.Delete(certificacion);
        }
    }
}
