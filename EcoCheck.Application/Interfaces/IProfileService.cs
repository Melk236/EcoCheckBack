
using EcoCheck.Domain.Entities;

namespace EcoCheck.Application.Interfaces
{
    public interface IProfileService
    {
        Task<ApplicationUser> GetUserByToken(string userName);
    }
}
