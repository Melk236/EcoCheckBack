using AutoMapper;
using EcoCheck.Infrastructure.Data;
using EcoCheck.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using EcoCheck.Domain.Exceptions;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Domain.Entities;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Interfaces;
namespace EcoCheck.Application.Services
{
    public class EmpresaCertificacionService:IEmpresaCertificacionService
    {
        private readonly AppDbContext _context;
        private readonly IRepository<EmpresaCertificacion> _repository;
        private readonly IMapper _mapper;
        public EmpresaCertificacionService(AppDbContext context,IMapper mapper,IRepository<EmpresaCertificacion> repository)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EmpresaCertificacionDto>> GetAll()
        {
            var empresaCertificaciones = await _repository.GetAll().ToListAsync();

            return _mapper.Map<List<EmpresaCertificacionDto>>(empresaCertificaciones);

        }

        public async Task<List<EmpresaCertificacionDto>> GetById(int id)//Este id que le llega es de la empresa para luego traernos las certificaciones adecuadas.
        {
            var empresaCertificaciones = await _repository.GetAll().Where(x => x.MarcaId == id).ToListAsync();

            if (empresaCertificaciones == null)
            {
                throw new NotFoundException("No se han encontrado certificaciones de la empresa con id "+id);

            }

            return _mapper.Map<List<EmpresaCertificacionDto>>(empresaCertificaciones);
        }

        public async Task<List<EmpresaCertificacionDto>> Create(IEnumerable<CreateEmpresaCertificacionDto> dto)
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


            await _repository.CreateRange(empresasCertificaciones);

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
