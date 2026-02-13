
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Domain.Entities;
using Microsoft.AspNetCore.Http;


namespace EcoCheck.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<UserDto> UpdateUser(int id,UpdateUserDto user);
        Task DeleteUser(int id);
        Task<string> ValidateFileAsync(IFormFile archivo);
        Task ChangePasswordAsync(int id,ChangePasswordDto dto);
        Task<string> GetRoleByUserAsync(ApplicationUser user);
    }
}
