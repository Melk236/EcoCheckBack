using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.UpdateDtos;

namespace EcoCheck.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<UserDto> UpdateUser(int id,UpdateUserDto user);
        Task DeleteUser(int id);
    }
}
