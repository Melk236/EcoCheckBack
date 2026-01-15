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
    public class ProductoService:IProductoService
    {
       
        private readonly IRepository<Productos> _repository;
        private readonly IMapper _mapper;
        public ProductoService(AppDbContext context,IMapper mapper,IRepository<Productos> repository)
        {
            
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductoDto>> GetAllProductos()
        {
            var productos = await _repository.GetAll().ToListAsync();

            return _mapper.Map<List<ProductoDto>>(productos);
        }
        
        public async Task<ProductoDto> GetProductoById(int id)
        {

            var producto = await _repository.GetById(id);

            if (producto==null)//Si es null lanzamos nuestra excepción de la clase NotFoundException.
            {
                throw new NotFoundException("No se ha encontrado el producto cone el id " + id);
            }

            return _mapper.Map<ProductoDto>(producto);

        }

        public async Task<ProductoDto> CreateProducto(CreateProductoDto dto)
        {
            if (String.IsNullOrEmpty(dto.Nombre) || String.IsNullOrEmpty(dto.Descripcion) || String.IsNullOrEmpty(dto.PaisOrigen) || String.IsNullOrEmpty(dto.ImagenUrl))
            {
                throw new BadRequestException("Uno o más campos del producto están vacíos");
            }

            var producto =_mapper.Map<Productos>(dto);
            

            await _repository.Create(producto);
           

            return _mapper.Map<ProductoDto>(producto);

        }

        public async Task<ProductoDto> UpdateProducto(int id,UpdateProductoDto dto)
        {

            if (String.IsNullOrEmpty(dto.Nombre) || String.IsNullOrEmpty(dto.Descripcion) || String.IsNullOrEmpty(dto.PaisOrigen) || String.IsNullOrEmpty(dto.ImagenUrl))
            {
                throw new BadRequestException("Uno o más campos del producto están vacíos");
            }
            
            var producto = await _repository.GetById(id);

            if (producto==null)
            {
                throw new NotFoundException("No se ha encontrado el producto con id " + id);
            }

            //Actualizamos los nuevos datos del producto
            _mapper.Map(dto, producto);

            await _repository.Update(producto);

            return _mapper.Map<ProductoDto>(producto);
        }

        public async Task EliminarProducto(int id)
        {
            var producto = await _repository.GetById(id);

            if (producto==null)
            {
                throw new NotFoundException("No se ha encontrado el producto con id" + id);
            }

            

            await _repository.Delete(producto);

        }
    }
}
