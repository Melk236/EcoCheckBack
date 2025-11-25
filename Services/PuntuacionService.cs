using AutoMapper;
using EcoCheck.Data;
using EcoCheck.Dtos;
using EcoCheck.Dtos.CreateDtos;
using EcoCheck.Dtos.UpdateDtos;
using EcoCheck.Exceptions;
using EcoCheck.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoCheck.Services
{
    public class PuntuacionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PuntuacionService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PuntuacionDto>> GetAllPuntuaciones()
        {
            var puntuaciones = await _context.Puntuacion.ToListAsync();

            return _mapper.Map<List<PuntuacionDto>>(puntuaciones);
        }

        public async Task<PuntuacionDto> GetPuntuacionById(int id)
        {
            var puntuacion=await _context.Puntuacion.FindAsync(id);

            if (puntuacion==null)
            {
                throw new NotFoundException("no se ha encontrado la puntuación con el id "+id);
            }

            return _mapper.Map<PuntuacionDto>(puntuacion);
        }

        public async Task<PuntuacionDto> CrearPuntuacion(CreatePuntuacionDto dto)
        {
            if (dto.ProductoId<=0 || dto.Gobernanza<=0 || dto.ValorSocial<=0 || dto.ValorAmbiental<=0 || dto.Valor<=0)
            {
                throw new BadRequestException("Uno o más campos son inválidos");
            }

            var puntuacion=_mapper.Map<Puntuacion>(dto);

            _context.Puntuacion.Add(puntuacion);
            await _context.SaveChangesAsync();

            return _mapper.Map<PuntuacionDto>(puntuacion);
        }

        public async Task<PuntuacionDto> ActualizarPuntuacion(int id,UpdatePuntuacionDto dto)
        {
            var puntuacion = await _context.Puntuacion.FindAsync(id);

            if (puntuacion==null)
            {
                throw new NotFoundException("No se ha encontrado la puntuación con el id "+id);
            }

            _mapper.Map(dto,puntuacion);

            await _context.SaveChangesAsync();

            return _mapper.Map<PuntuacionDto>(puntuacion);
        }

        public async Task EliminarPuntuacion(int id)
        {
            var puntuacion = await _context.Puntuacion.FindAsync(id);

            if (puntuacion == null)
            {
                throw new NotFoundException("No se ha encontrado la puntuación con el id " + id);
            }

            _context.Puntuacion.Remove(puntuacion);
            await _context.SaveChangesAsync();
        }
    }
}
