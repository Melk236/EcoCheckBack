namespace EcoCheck.Application.Dtos.UpdateDtos
{
    public class UpdateMaterialDto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public bool Reciclable { get; set; }
        public float ImpactoCarbono { get; set; }
    }
}
