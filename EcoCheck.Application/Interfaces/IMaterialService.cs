
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;

namespace EcoCheck.Application.Interfaces
{
    public interface IMaterialService
    {
        public Task<List<MaterialDto>> GetAllMaterial();
        public Task<List<MaterialDto>> GetMaterialById(int id);
        public Task<List<MaterialDto>> CrearMaterial(IEnumerable<CreateMaterialDto> dto);
        public Task<MaterialDto> ActualizarMaterial(int id, UpdateMaterialDto dto);
        public Task EliminarMaterial(int id);
    }
}
