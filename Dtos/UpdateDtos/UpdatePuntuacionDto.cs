namespace EcoCheck.Dtos.UpdateDtos
{
    public class UpdatePuntuacionDto
    {
        public int ProductoId { get; set; }
        public float Valor { get; set; }
        public float ValorAmbiental { get; set; }
        public float ValorSocial { get; set; }
        public float Gobernanza { get; set; }
    }
}
