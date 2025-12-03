using EcoCheck.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCheck.Dtos
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public bool Reciclable { get; set; }
        public float ImpactoCarbono { get; set; }
      

        
    }
}
