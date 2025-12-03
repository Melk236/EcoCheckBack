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
    public class MaterialService
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

        public async Task<List<MaterialDto>> CrearMaterial(CreateMaterialDto[] dto)//Pasamos un array con todos los materiales del producto escaneado
        {

           
            for(int i = 0;i<dto.Length;i++)
            {
                if (String.IsNullOrEmpty(dto[i].Nombre)  || dto[i].ImpactoCarbono<=0 || dto[i].ProductoId<=0)
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
