using System.ComponentModel.DataAnnotations;

namespace EcoCheck.Domain.Entities
{
    public class Puntuacion
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public DateTime Fecha { get; set; }=DateTime.Now;
        public float Valor { get; set; }
        public float ValorAmbiental { get; set; }
        public float ValorSocial { get; set; }
        

    }
}
