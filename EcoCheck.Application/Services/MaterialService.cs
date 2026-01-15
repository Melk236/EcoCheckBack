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
    public class MaterialService:IMaterialService
    {
        
        private readonly IRepository<Material> _repository;
        private readonly IMapper _mapper;

        public MaterialService(IMapper mapper,IRepository<Material> repository)
        {
            
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<List<MaterialDto>> GetAllMaterial()
        {
            var materiales = await _repository.GetAll().ToListAsync();

            return _mapper.Map<List<MaterialDto>>(materiales);

        }

        public async Task<List<MaterialDto>> GetMaterialById(int id)//Este id es el del producto para traernos aquellos materiales que pertenecen al producto en concreto
        {
            var materiales=await _repository.GetAll().Where(x=>x.ProductoId==id).ToListAsync();//Nos traemos los materiales especificos del producto

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
            
            await _repository.CreateRange(materiales);



            return _mapper.Map<List<MaterialDto>>(materiales);

        }
        public async Task<MaterialDto> ActualizarMaterial(int id,UpdateMaterialDto dto)
        {
            var material = await _repository.GetById(id);

           if(material == null)
            {
                throw new NotFoundException("No se ha encontrado el material con el id " + id);
            }

           _mapper.Map(dto,material);

            await _repository.Update(material);


           return _mapper.Map<MaterialDto>(material);
        }

        public async Task EliminarMaterial(int id)
        {
            var material = await _repository.GetById(id);

            if (material==null)
            {
                throw new NotFoundException("No se ha encontrado el material con el id "+id);
            }

            

            await _repository.Delete(material);


        }
    }
}
