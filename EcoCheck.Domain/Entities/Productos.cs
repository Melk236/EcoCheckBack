using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCheck.Domain.Entities
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }    
        public string Categoria { get; set; }
        public string PaisOrigen { get; set; }

        public string Descripcion { get; set; }
        public string Ingredientes { get; set; }
        public float EcoScore { get; set; }
        public string ImagenUrl { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;    
    }
}
