using EcoCheck.Domain.Exceptions;
using EcoCheck.Application.Interfaces;

using EcoCheck.Domain.Interfaces;
using AutoMapper;
using EcoCheck.Application.Dtos;

namespace EcoCheck.Application.Services
{
    public class ProfileService : IProfileService
    {
        private IAuthRepository _repository;
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public ProfileService(IAuthRepository repository, IMapper mapper,IUserRepository userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserByToken(string userName)
        {
            if (userName == null) throw new BadRequestException("El token no incluye el nombre del usuario");
            var usuario = await _repository.GetUserByNameAsync(userName);

            if (usuario == null) throw new NotFoundException("Error, no se ha podido identificar al usuario con los claims proporcionados");

            var rol = await _userRepository.GetRolesUserAsync(usuario);

            var user = _mapper.Map<UserDto>(usuario);
            user.roleName = rol;

            return user;           
        }
    }
}
