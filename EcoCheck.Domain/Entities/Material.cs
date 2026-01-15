using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCheck.Domain.Entities
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public bool Reciclable { get;set; }
        public float ImpactoCarbono { get; set; }
      
        [ForeignKey("ProductoId")]
        public Productos Producto { get; set; }

    }
}
