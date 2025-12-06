using System.ComponentModel.DataAnnotations;

namespace EcoCheck.Models
{
    public class Certificacion
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}
