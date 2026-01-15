

using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;

namespace EcoCheck.Application.Interfaces
{
    public interface IEmpresaCertificacionService
    {
        public Task<List<EmpresaCertificacionDto>> GetAll();
        public Task<List<EmpresaCertificacionDto>> GetById(int id);
        public Task<List<EmpresaCertificacionDto>> Create(IEnumerable<CreateEmpresaCertificacionDto> dto);
        public Task<EmpresaCertificacionDto> Update(int id, UpdateEmpresaCertificacionDto dto);
        public Task Delete(int id);
    }
}
