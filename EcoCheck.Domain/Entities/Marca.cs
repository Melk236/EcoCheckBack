using System.ComponentModel.DataAnnotations;


namespace EcoCheck.Domain.Entities
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } 
        public string? EmpresaMatriz { get; set; }
        public string? PaisSede { get; set; }
        public string? SitioWeb { get; set; }
        
        public float? PuntuacionSocial { get; set; }
        public string? Descripcion { get; set;}
        public string? Controversias { get; set; }
        public string? Logo { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;   

    }
}
