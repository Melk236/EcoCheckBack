

using AutoMapper;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Exceptions;
using EcoCheck.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
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

        public async Task<UserDto> UpdateUser(int id, UpdateUserDto user,IFormFile archivo)
        {
            //Comprobamos que el archivo es válido y devovemos la url que se guardará en la base de datos
            var urlImagen = await ValidateFileAsync(archivo);
            user.Imagen = urlImagen;

            if (string.IsNullOrEmpty(user.UserName) || 
                string.IsNullOrEmpty(user.Nombre) ||
                string.IsNullOrEmpty(user.Apellido)    
                ) throw new BadRequestException("Uno o más campos son inválidos");
            
            var usuario = await _userRepository.GetById(id);

            if (usuario == null) throw new NotFoundException("No se ha encontrado el usuario con el id " + usuario);
           
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

        public async Task<string> ValidateFileAsync(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0) throw new BadRequestException("Error, archivo de imagen vacío");

            var extensionesValidas = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".webp", ".bmp" };

            if (!extensionesValidas.Contains(archivo.FileName)) throw new BadRequestException($"Formato no permitido. Solo se aceptan imágenes: {string.Join(", ", extensionesValidas)}");

            string[] mimeTiposPermitidos = { "image/jpeg", "image/png", "image/gif", "image/webp", "image/bmp" };

            if (!mimeTiposPermitidos.Contains(archivo.ContentType)) throw new BadRequestException("El tipo de contenido no corresponde a una imagen válida.");

            var carpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            //Creamos este directorio si no existe
            Directory.CreateDirectory(carpeta);

            var nombreUnico = $"{Guid.NewGuid()}{Path.GetExtension(archivo.FileName.ToLowerInvariant())}";
            var ruta = Path.Combine(carpeta, nombreUnico);

            using(var stream=new FileStream(ruta, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
            };

            var rutaImagen = "uploads/" + nombreUnico;

            return rutaImagen;
        }
    }
}
