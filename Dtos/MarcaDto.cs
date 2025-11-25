namespace EcoCheck.Dtos
{
    public class MarcaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? EmpresaMatriz { get; set; }

        public string PaisSede { get; set; }
        public string? SitioWeb { get; set; }
        public string? Certificaciones { get; set; }
        public float PuntuacionSocial { get; set; }
        public float PuntuacionAmbiental { get; set; }
        public float PuntuacionGobernanza { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
