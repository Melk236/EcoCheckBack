

using EcoCheck.Domain.Entities;

namespace EcoCheck.Application.Interfaces
{
   public interface IJwtService
    {
        public string GenerateToken(ApplicationUser user,string rol);

    }
}
