using AutoMapper;

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
    public class MarcaService:IMarcaService
    {
        
        private readonly IRepository<Marca> _repository;
        private readonly IMapper _mapper;

        public MarcaService(IMapper mapper,IRepository<Marca> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<MarcaDto>> GetAllMarcas()
        {
            var marcas = await _repository.GetAll().ToListAsync();


            return _mapper.Map<List<MarcaDto>>(marcas);
        }

        public async Task<MarcaDto> GetMarcaById(int id)
        {
            var marca = await _repository.GetById(id);

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
            var marcaEncontrada = await _repository.GetAll().AnyAsync(x=>x.Nombre.ToLower()==dto.Nombre.ToLower());//Buscamos si ya existe una empresa con ese nombre

            if (marcaEncontrada)
            {
                throw new BadRequestException("Ya existe esta empresa en la base de datos");
            }

            var marca=_mapper.Map<Marca>(dto);

            
            await _repository.Create(marca);

            return _mapper.Map<MarcaDto>(marca);

        }
        public async Task<MarcaDto> ActualizarMarca(int id,UpdateMarcaDto dto)
        {
            var marca = await _repository.GetById(id);

            if (marca==null)
            {
                throw new NotFoundException("No se ha encontrado la marca con el id "+id);
            }

            _mapper.Map(dto, marca);
            await _repository.Update(marca);

            return _mapper.Map<MarcaDto>(marca);

        }
        public async Task BorrarMarca(int id)
        {
            var marca = await _repository.GetById(id);

            if (marca == null)
            {
                throw new NotFoundException("No se ha encontrado la marca con el id " + id);
            }

            await _repository.Delete(marca);


        }
    }
}
