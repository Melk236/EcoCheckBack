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
    public class PuntuacionService:IPuntuacionService
    {
        private readonly AppDbContext _context;
        private readonly IRepository<Puntuacion> _repository;
        private readonly IMapper _mapper;
        public PuntuacionService(AppDbContext context,IMapper mapper,IRepository<Puntuacion> repository)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PuntuacionDto>> GetAllPuntuaciones()
        {
            var puntuaciones = await _repository.GetAll().ToListAsync();

            return _mapper.Map<List<PuntuacionDto>>(puntuaciones);
        }

        public async Task<PuntuacionDto> GetPuntuacionById(int id)
        {
            var puntuacion=await _repository.GetById(id);

            if (puntuacion==null)
            {
                throw new NotFoundException("no se ha encontrado la puntuación con el id "+id);
            }

            return _mapper.Map<PuntuacionDto>(puntuacion);
        }

        public async Task<PuntuacionDto> CrearPuntuacion(CreatePuntuacionDto dto)
        {
            if (dto.ProductoId<=0  || dto.ValorSocial<=0 || dto.ValorAmbiental<=0 || dto.Valor<=0)
            {
                throw new BadRequestException("Uno o más campos son inválidos");
            }

            var puntuacion=_mapper.Map<Puntuacion>(dto);


            await _repository.Create(puntuacion);

            return _mapper.Map<PuntuacionDto>(puntuacion);
        }

        public async Task<PuntuacionDto> ActualizarPuntuacion(int id,UpdatePuntuacionDto dto)
        {
            var puntuacion = await _repository.GetById(id);

            if (puntuacion==null)
            {
                throw new NotFoundException("No se ha encontrado la puntuación con el id "+id);
            }

            _mapper.Map(dto,puntuacion);

            await _repository.Update(puntuacion);

            return _mapper.Map<PuntuacionDto>(puntuacion);
        }

        public async Task EliminarPuntuacion(int id)
        {
            var puntuacion = await _repository.GetById(id);

            if (puntuacion == null)
            {
                throw new NotFoundException("No se ha encontrado la puntuación con el id " + id);
            }

            
            await _repository.Delete(puntuacion);
        }
    }
}
