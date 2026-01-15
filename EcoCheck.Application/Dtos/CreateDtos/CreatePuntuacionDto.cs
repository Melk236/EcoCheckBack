namespace EcoCheck.Application.Dtos.CreateDtos
{
    public class CreatePuntuacionDto
    {
        public int ProductoId { get; set; }
        public float Valor { get; set; }
        public float ValorAmbiental { get; set; }
        public float ValorSocial { get; set; }
       
    }
}
