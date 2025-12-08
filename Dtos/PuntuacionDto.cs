namespace EcoCheck.Dtos
{
    public class PuntuacionDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public DateTime Fecha { get; set; }
        public float Valor { get; set; }
        public float ValorAmbiental { get; set; }
        public float ValorSocial { get; set; }
        
    }
}
