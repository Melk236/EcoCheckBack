
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;

namespace EcoCheck.Application.Interfaces
{
    public interface IProductoService
    {
        public Task<List<ProductoDto>> GetAllProductos();
        public Task<ProductoDto> GetProductoById(int id);
        public Task<ProductoDto> CreateProducto(CreateProductoDto dto);
        public Task<ProductoDto> UpdateProducto(int id, UpdateProductoDto dto);
        public Task<List<ProductoDto>> GetProductosComparacion(string categoria,double nota);
        public Task EliminarProducto(int id);
    }
}
