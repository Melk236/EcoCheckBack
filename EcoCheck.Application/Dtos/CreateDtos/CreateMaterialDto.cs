namespace EcoCheck.Application.Dtos.CreateDtos
{
    public class CreateMaterialDto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public bool Reciclable { get; set; }
        public float ImpactoCarbono { get; set; }
    }
}
