using AutoMapper;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Domain.Entities;

namespace EcoCheck.Application.Mappers
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
