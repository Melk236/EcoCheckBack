using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCheck.Models
{
    public class EmpresaCertificacion
    {
        [Key]
        public int Id {  get; set; }
        public int MarcaId { get; set; }
        public int CertificacionId { get; set; }

        [ForeignKey("MarcaId")]    
        public Marca Marca { get; set; }

        [ForeignKey("CertificacionId")]
        public Certificacion Certificacion { get; set; }

    }
}
