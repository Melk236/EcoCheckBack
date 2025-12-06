using AutoMapper;
using EcoCheck.Data;
using EcoCheck.Dtos;
using Microsoft.EntityFrameworkCore;
using EcoCheck.Exceptions;
using EcoCheck.Dtos.CreateDtos;
using EcoCheck.Models;
namespace EcoCheck.Services
{
    public class CertificacionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CertificacionService(AppDbContext context,IMapper mapper)
        {   
            _context = context;
            _mapper = mapper;
        }

            
        public async Task<List<CertificacionDto>> GetAllCertificaciones()
        {

            var certificaciones = await _context.Certificaciones.ToListAsync();

            return _mapper.Map<List<CertificacionDto>>(certificaciones);
        }

        public async Task<CertificacionDto> GetCertificacionById(int id)
        {
            var certificacion=await _context.Certificaciones.FindAsync(id);

            if (certificacion==null)
            {
                throw new NotFoundException("No se ha encontrado la certificación con el id " + id);
            }

            return _mapper.Map<CertificacionDto>(certificacion);
        } 

        public async Task<List<CertificacionDto>> CreateCerticacion(CreateCertificacionDto[] dto)
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

            _context.Certificaciones.AddRange(certificaciones);

            await _context.SaveChangesAsync();

            return _mapper.Map<List<CertificacionDto>>(certificaciones);
        }

        public async Task DeleteCertificacion(int id)
        {
            var certificacion = await _context.Certificaciones.FindAsync(id);

            if (certificacion==null)
            {
                throw new NotFoundException("No se ha encontrado la certificación con el id "+id);
            }

            _context.Certificaciones.Remove(certificacion);

            await _context.SaveChangesAsync();
        }
    }
}
