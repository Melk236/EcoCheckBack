

using EcoCheck.Domain.Entities;

namespace EcoCheck.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<ApplicationUser> GetAllUsers();
        Task<ApplicationUser> GetById(int id);
        Task UpdateUser(ApplicationUser user);
        Task DeleteUser(ApplicationUser user);
        

    }
}
