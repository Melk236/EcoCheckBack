

namespace EcoCheck.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? UrlImagen { get;set; }
        public DateTime FechaRegistro { get; set; } 

    }
}
