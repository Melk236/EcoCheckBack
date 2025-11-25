using AutoMapper;
using EcoCheck.Dtos;
using EcoCheck.Dtos.CreateDtos;
using EcoCheck.Dtos.UpdateDtos;
using EcoCheck.Models;

namespace EcoCheck.Mappers
{
    public class ProductoProfile:Profile
    {
        public ProductoProfile()
        {
            // Para devolver datos al cliente
            CreateMap<Productos, ProductoDto>();

            // Para crear un producto desde el DTO
            CreateMap<CreateProductoDto, Productos>();

            // Para actualizar un producto existente desde el DTO
            CreateMap<UpdateProductoDto, Productos>();
        }
    }
}
