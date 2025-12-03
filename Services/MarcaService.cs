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
    public class MarcaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MarcaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MarcaDto>> GetAllMarcas()
        {
            var marcas = await _context.Marcas.ToListAsync();

            return _mapper.Map<List<MarcaDto>>(marcas);
        }

        public async Task<MarcaDto> GetMarcaById(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);

            if (marca==null)
            {
                throw new NotFoundException("No se ha encontrado la marca con el id "+id);
            }

            return _mapper.Map<MarcaDto>(marca);
        }

        public async Task<MarcaDto> CrearMarca(CreateMarcaDto dto)
        {
            if (String.IsNullOrEmpty(dto.Nombre))
            {
                throw new BadRequestException("Uno o más campos están vacíos");
            }
            var marcaEncontrada = await _context.Marcas.AnyAsync(x=>x.Nombre==dto.Nombre);//Buscamos si ya existe una empresa con ese nombre

            if (marcaEncontrada)
            {
                throw new BadRequestException("Ya existe esta empresa en la base de datos");
            }
            var marca=_mapper.Map<Marca>(dto);

            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            return _mapper.Map<MarcaDto>(marca);

        }
        public async Task<MarcaDto> ActualizarMarca(int id,UpdateMarcaDto dto)
        {
            var marca = await _context.Marcas.FindAsync(id);

            if (marca==null)
            {
                throw new NotFoundException("No se ha encontrado la marca con el id "+id);
            }

            _mapper.Map(dto, marca);
            await _context.SaveChangesAsync();

            return _mapper.Map<MarcaDto>(marca);

        }
        public async Task BorrarMarca(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
            {
                throw new NotFoundException("No se ha encontrado la marca con el id " + id);
            }

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();


        }
    }
}
