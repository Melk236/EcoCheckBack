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
    public class ProductoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductoService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductoDto>> GetAllProductos()
        {
            var productos = await _context.Producto.ToListAsync();

            return _mapper.Map<List<ProductoDto>>(productos);
        }
        
        public async Task<ProductoDto> GetProductoById(int id)
        {

            var producto = await _context.Producto.FindAsync(id);

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
            _context.Producto.Add(producto);

            await _context.SaveChangesAsync();
           

            return _mapper.Map<ProductoDto>(producto);

        }

        public async Task<ProductoDto> UpdateProducto(int id,UpdateProductoDto dto)
        {

            if (String.IsNullOrEmpty(dto.Nombre) || String.IsNullOrEmpty(dto.Descripcion) || String.IsNullOrEmpty(dto.PaisOrigen) || String.IsNullOrEmpty(dto.ImagenUrl))
            {
                throw new BadRequestException("Uno o más campos del producto están vacíos");
            }
            
            var producto = await _context.Producto.FindAsync(id);

            if (producto==null)
            {
                throw new NotFoundException("No se ha encontrado el producto con id " + id);
            }

            //Actualizamos los nuevos datos del producto
            _mapper.Map(dto, producto);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductoDto>(producto);
        }

        public async Task EliminarProducto(int id)
        {
            var producto = await _context.Producto.FindAsync(id);

            if (producto==null)
            {
                throw new NotFoundException("No se ha encontrado el producto con id" + id);
            }

            _context.Producto.Remove(producto);

            await _context.SaveChangesAsync();

        }
    }
}
