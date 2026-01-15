
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;

namespace EcoCheck.Application.Interfaces
{
    public interface IPuntuacionService
    {
        public Task<List<PuntuacionDto>> GetAllPuntuaciones();
        public Task<PuntuacionDto> GetPuntuacionById(int id);
        public Task<PuntuacionDto> CrearPuntuacion(CreatePuntuacionDto dto);
        public Task<PuntuacionDto> ActualizarPuntuacion(int id, UpdatePuntuacionDto dto);
        public Task EliminarPuntuacion(int id);
    }
}
