
using EcoCheck.Application.Dtos;

namespace EcoCheck.Application.Interfaces
{
    public interface IProfileService
    {
        Task<UserDto> GetUserByToken(string userName);
    }
}
