using AutoMapper;
using EcoCheck.Data;
using EcoCheck.Dtos;
using Microsoft.EntityFrameworkCore;
using EcoCheck.Exceptions;
using EcoCheck.Dtos.CreateDtos;
using EcoCheck.Models;
using EcoCheck.Dtos.UpdateDtos;
namespace EcoCheck.Services
{
    public class EmpresaCertificacionService
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public EmpresaCertificacionService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmpresaCertificacionDto>> GetAll()
        {
            var empresaCertificaciones = await _context.EmpresaCertificacion.ToListAsync();

            return _mapper.Map<List<EmpresaCertificacionDto>>(empresaCertificaciones);

        }

        public async Task<List<EmpresaCertificacionDto>> GetById(int id)//Este que le llega es de la empresa para luego traernos las certificaciones adecuadas.
        {
            var empresaCertificaciones = await _context.EmpresaCertificacion.Where(x => x.MarcaId == id).ToListAsync();

            if (empresaCertificaciones == null)
            {
                throw new NotFoundException("No se han encontrado certificaciones de la empresa con id "+id);

            }

            return _mapper.Map<List<EmpresaCertificacionDto>>(empresaCertificaciones);
        }

        public async Task<List<EmpresaCertificacionDto>> Create(CreateEmpresaCertificacionDto[] dto)
        {
            if (dto==null)
            {
                throw new BadRequestException("El array empresaCertificación está vacío");
            }
             foreach (var item in dto)
             {
                if (item.MarcaId<=0 || item.CertificacionId<=0)
                {
                    throw new BadRequestException("Uno de los ids es negativo");
                }
             }

             var empresasCertificaciones=_mapper.Map<List<EmpresaCertificacion>>(dto);

            _context.EmpresaCertificacion.AddRange(empresasCertificaciones);
            await _context.SaveChangesAsync();

            return _mapper.Map<List<EmpresaCertificacionDto>>(empresasCertificaciones);

        }

        public async Task<EmpresaCertificacionDto> Update(int id,UpdateEmpresaCertificacionDto dto)
        {
            var empresaCertificacion=await _context.EmpresaCertificacion.FindAsync(id);

            if (empresaCertificacion==null)
            {
                throw new NotFoundException("No se ha encontrado la relación empresa-certificación con el id " + id);
            }

            _mapper.Map(dto, empresaCertificacion);

            await _context.SaveChangesAsync();

            return _mapper.Map<EmpresaCertificacionDto>(empresaCertificacion);
        }

        public async Task Delete(int id)
        {
            var empresaCertificacion = await _context.EmpresaCertificacion.FindAsync(id);

            if (empresaCertificacion == null)
            {
                throw new NotFoundException("No se ha encontrado la relación empresa-certificación con el id " + id);
            }

            _context.EmpresaCertificacion.Remove(empresaCertificacion);

            await _context.SaveChangesAsync();
        }

    }
}
