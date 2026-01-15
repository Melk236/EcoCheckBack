using AutoMapper;
using EcoCheck.Infrastructure.Data;
using EcoCheck.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using EcoCheck.Domain.Exceptions;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Domain.Entities;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Application.Interfaces;

namespace EcoCheck.Application.Services
{
    public class MaterialService:IMaterialService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public MaterialService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<MaterialDto>> GetAllMaterial()
        {
            var materiales = await _context.Material.ToListAsync();

            return _mapper.Map<List<MaterialDto>>(materiales);

        }

        public async Task<List<MaterialDto>> GetMaterialById(int id)//Este id es el del producto para traernos aquellos materiales que pertenecen al producto en concreto
        {
            var materiales=await _context.Material.Where(x=>x.ProductoId==id).ToListAsync();//Nos traemos los materiales especificos del producto

            return _mapper.Map<List<MaterialDto>>(materiales);
        }

        public async Task<List<MaterialDto>> CrearMaterial(IEnumerable<CreateMaterialDto> dto)//Pasamos un array con todos los materiales del producto escaneado
        {

           
            foreach(var item in dto)
            {
                if (String.IsNullOrEmpty(item.Nombre)  || item.ImpactoCarbono<=0 || item.ProductoId<=0)
                {
                    throw new BadRequestException("Uno o más campos no son válidos");
                }

               

            }
            //Si no hay un error agregamos todos los materiales de golpe.
            var materiales = _mapper.Map<List<Material>>(dto);
            _context.Material.AddRange(materiales);
            await _context.SaveChangesAsync();



            return _mapper.Map<List<MaterialDto>>(materiales);

        }
        public async Task<MaterialDto> ActualizarMaterial(int id,UpdateMaterialDto dto)
        {
           var material=await _context.Material.FindAsync(id);

           if(material == null)
            {
                throw new NotFoundException("No se ha encontrado el material con el id " + id);
            }

           _mapper.Map(dto,material);

            await _context.SaveChangesAsync();


           return _mapper.Map<MaterialDto>(material);
        }

        public async Task EliminarMaterial(int id)
        {
            var material = await _context.Material.FindAsync(id);

            if (material==null)
            {
                throw new NotFoundException("No se ha encontrado el material con el id "+id);
            }

            _context.Material.Remove(material);

            await _context.SaveChangesAsync();


        }
    }
}
