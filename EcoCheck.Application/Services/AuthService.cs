

using EcoCheck.Application.Dtos;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Interfaces;
using EcoCheck.Domain.Exceptions;
using EcoCheck.Domain.Entities;
namespace EcoCheck.Application.Services
{
    
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        //Comprobamos las credenciales del usuario
        public async Task<ApplicationUser> CheckUser(LoginDto dto)
        {
            if (dto.User==null || dto.Password==null)
            {
                throw new BadRequestException("Uno o más campos están vacíos");
            }

            var usuario = await _repository.GetUserByNameAsync(dto.User) ?? throw new NotFoundException("No se ha encontrado el usuario con nombre" + dto.User);
            var success =await _repository.CheckUserAsync(usuario,dto.Password);

            if (!success) throw new UnauthorizedException("Credenciales inválidas");

            return usuario;
        }

        public async Task<ApplicationUser> CreateUser(LoginDto dto)
        {
            if (dto.User==null || dto.Password==null)
            {
                throw new BadRequestException("Uno o más campos están vacíos");
            }

            //Comprobamos que el usuario no exista
            var usuario = await _repository.GetUserByNameAsync(dto.User);

            if (usuario != null) {
                throw new ConflictException("Error, este usuario ya existe");
            }

            //Creamos un user de tipo ApplicationUser y si lo pasamos al repositorio para que cree el usuario.
            var user = new ApplicationUser
            {
                UserName=dto.User
            };

            var created = await _repository.CreateUserAsync(user,dto.Password);

            if (!created) throw new Exception("No se ha podido crear el usuario");

            return await _repository.GetUserByNameAsync(dto.User);
        }
    }
}
