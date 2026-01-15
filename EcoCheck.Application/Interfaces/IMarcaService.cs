

using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;

namespace EcoCheck.Application.Interfaces
{
    public interface IMarcaService
    {
        public Task<List<MarcaDto>> GetAllMarcas();
        public Task<MarcaDto> GetMarcaById(int id);
        public Task<MarcaDto> CrearMarca(CreateMarcaDto dto);
        public Task<MarcaDto> ActualizarMarca(int id, UpdateMarcaDto dto);
        public Task BorrarMarca(int id);
    }
}
