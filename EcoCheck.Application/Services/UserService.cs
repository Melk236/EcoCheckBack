

using AutoMapper;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Exceptions;
using EcoCheck.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoCheck.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var usuarios= await _userRepository.GetAllUsers().ToListAsync();

            return _mapper.Map<List<UserDto>>(usuarios);    
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var usuario=await _userRepository.GetById(id);

            return usuario == null
                ? throw new NotFoundException("No se ha encontrado el usuario con el id " + id)
                : _mapper.Map<UserDto>(usuario);
        }

        public async Task<UserDto> UpdateUser(int id, UpdateUserDto user)
        {
            if (user.UserName == null) throw new BadRequestException("Uno o más campos son inválidos");
            Console.WriteLine(user.Apellido);
            var usuario = await _userRepository.GetById(id);

            if (usuario == null) throw new NotFoundException("No se ha encontrado el usuario con el id " + usuario);
            Console.WriteLine(usuario);
            _mapper.Map(user,usuario);

            await _userRepository.UpdateUser(usuario);

            return _mapper.Map<UserDto>(usuario);

        }
        public async Task DeleteUser(int id)
        {
            var usuario = await _userRepository.GetById(id);

            if (usuario == null) throw new NotFoundException("No se ha encontrado con el usuario con el id " + id);

            await _userRepository.DeleteUser(usuario);
            
        }
    }
}
