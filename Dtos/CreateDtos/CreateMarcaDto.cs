namespace EcoCheck.Dtos.CreateDtos
{
    public class CreateMarcaDto
    {
        public string Nombre { get; set; }
        public string? EmpresaMatriz { get; set; }

        public string PaisSede { get; set; }
        public string? SitioWeb { get; set; }
        public string? Certificaciones { get; set; }
        public float PuntuacionSocial { get; set; }
        public string? Controversias { get; set; }
        public string? Descripcion { get; set; }
        public string? Logo { get; set; }
       
    }
}
