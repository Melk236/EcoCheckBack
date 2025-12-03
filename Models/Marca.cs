using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EcoCheck.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? EmpresaMatriz { get; set; }
        public string? PaisSede { get; set; }
        public string? SitioWeb { get; set; }
        public string? Certificaciones { get; set; }
        public float? PuntuacionSocial { get; set; }
        public string? Descripcion { get; set;}
        public string? Controversias { get; set; }

        public DateTime FechaActualizacion { get; set; } = DateTime.Now;   

    }
}
