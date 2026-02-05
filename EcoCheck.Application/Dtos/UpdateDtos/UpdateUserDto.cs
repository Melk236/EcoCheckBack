

namespace EcoCheck.Application.Dtos.UpdateDtos
{
    public class UpdateUserDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
