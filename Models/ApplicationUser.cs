using Microsoft.AspNetCore.Identity;

namespace EcoCheck.Models
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

    }
}
