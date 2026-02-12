

using AutoMapper;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Entities;
using EcoCheck.Domain.Exceptions;
using EcoCheck.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcoCheck.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(IUserRepository userRepository,IMapper mapper,UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var usuarios= await _userRepository.GetAllUsers().ToListAsync();
            var users = new List<UserDto>();

            foreach(var usuario in usuarios)
            {
                var rol = await _userRepository.GetRolesUserAsync(usuario);

                users.Add(_mapper.Map<UserDto>(usuario));
                users[users.Count() - 1].roleName = rol;
            }

            return users;    
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var usuario=await _userRepository.GetById(id);

            if (usuario == null) throw new NotFoundException("No se ha encontrado el usuario con el id " + id);

            var rol = await _userRepository.GetRolesUserAsync(usuario);
            var users = _mapper.Map<UserDto>(usuario);

            users.roleName = rol;
            return users;
        }

        public async Task<UserDto> UpdateUser(int id, UpdateUserDto user)
        {
            //Comprobamos que el archivo es válido y devovemos la url que se guardará en la base de datos
            var urlImagen = "";

            if (user.Imagen!=null && user.Imagen.Length>=0)
            {
                 urlImagen = await ValidateFileAsync(user.Imagen);
            }
                
            

            if (string.IsNullOrEmpty(user.UserName) || 
                string.IsNullOrEmpty(user.Nombre) ||
                string.IsNullOrEmpty(user.Apellido)    
                ) throw new BadRequestException("Uno o más campos son inválidos");
            
            var usuario = await _userRepository.GetById(id);

            if (usuario == null) throw new NotFoundException("No se ha encontrado el usuario con el id " + usuario);

            
            _mapper.Map(user, usuario);

            //Añdimos la url al usuario
            if (!string.IsNullOrEmpty(urlImagen)) usuario.UrlImagen = urlImagen;

            await _userRepository.UpdateUser(usuario);

            var rol = await _userRepository.GetRolesUserAsync(usuario);
            var users = _mapper.Map<UserDto>(usuario);
            users.roleName = rol;

            return users;

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
            bool esValido = true;
            foreach(var item in extensionesValidas)
            {
                if (archivo.FileName.Contains(item)) esValido = true;
            }

            if (!esValido) throw new BadRequestException($"Formato no permitido. Solo se aceptan imágenes: {string.Join(", ", extensionesValidas)}");



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
        //Método para cambiar la contraseña del usuario
        public async Task ChangePasswordAsync(int id, ChangePasswordDto dto)
        {
            var usuario = await _userRepository.GetById(id) ?? throw new NotFoundException("No se ha encontrado el usuario con el id " + id);

            //Si la nueva contraseña es la misma que la antigua nos salimos del método sin dar información adicional
            if (dto.NewPassword == dto.Password) return; 
            var identityResult = await _userManager.ChangePasswordAsync(usuario,dto.Password,dto.NewPassword);

            if (!identityResult.Succeeded) throw new ForbiddenException("Usted, no está autorizado para realizar esta acción");

        }
    }
}
