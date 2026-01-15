
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;

namespace EcoCheck.Application.Interfaces
{
    public interface ICertificacionService
    {
        public Task<List<CertificacionDto>> GetAllCertificaciones();
        public Task<CertificacionDto> GetCertificacionById(int id);
        public Task<List<CertificacionDto>> CreateCerticacion(IEnumerable<CreateCertificacionDto> dto);
        public Task DeleteCertificacion(int id);

    }
}
