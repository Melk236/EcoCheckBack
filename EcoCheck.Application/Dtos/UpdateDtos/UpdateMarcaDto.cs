namespace EcoCheck.Application.Dtos.UpdateDtos
{
    public class UpdateMarcaDto
    {
        public string Nombre { get; set; }
        public string? EmpresaMatriz { get; set; }

        public string PaisSede { get; set; }
        public string? SitioWeb { get; set; }
        public float PuntuacionSocial { get; set; }
        public string? Controversias { get; set; }
        
        public string? Descripcion { get; set; }
    }
}
