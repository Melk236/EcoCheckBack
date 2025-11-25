namespace EcoCheck.Dtos.UpdateDtos
{
    public class UpdateProductoDto
    {
        public string Nombre { get; set; }
        public int MarcaId { get; set; }
        public string Categoria { get; set; }
        public string PaisOrigen { get; set; }
        public string Descripcion { get; set; }
        public float EcoScore { get; set; }
        public string ImagenUrl { get; set; }
    }
}
