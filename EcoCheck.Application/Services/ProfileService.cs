using EcoCheck.Domain.Exceptions;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Entities;
using EcoCheck.Domain.Interfaces;

namespace EcoCheck.Application.Services
{
    public class ProfileService : IProfileService
    {
        private IAuthRepository _repository;
        public ProfileService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApplicationUser> GetUserByToken(string userName)
        {
            if (userName == null) throw new BadRequestException("El token no incluye el nombre del usuario");
            var usuario = await _repository.GetUserByNameAsync(userName);

            if (usuario == null) throw new NotFoundException("Error, no se ha podido identificar al usuario con los claims proporcionados");

            return usuario;           
        }
    }
}
