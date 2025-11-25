namespace EcoCheck.Dtos.UpdateDtos
{
    public class UpdateMaterialDto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public float Porcentaje { get; set; }
        public string Origen { get; set; }
        public float ImpactoCarbono { get; set; }
    }
}
