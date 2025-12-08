using EcoCheck.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoCheck.Data.Seeders
{
    public class EmpresaCertificacionSeeder
    {
        private readonly AppDbContext _context;

        public EmpresaCertificacionSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task seedEmpresaCertificacion()
        {
            if (await _context.EmpresaCertificacion.AnyAsync())
            {
                return;
            }

            var relaciones = new List<EmpresaCertificacion>();

            // Obtener todas las marcas y certificaciones
            var marcas = await _context.Marcas.ToListAsync();
            var certs = await _context.Certificaciones.ToDictionaryAsync(c => c.Nombre);

            // Coca-Cola
            relaciones.Add(new EmpresaCertificacion
            {
                MarcaId = marcas.First(m => m.Nombre == "Coca-Cola").Id,
                CertificacionId = certs["ISO 14001"].Id
            });

            // ElPozo
            var elPozoId = marcas.First(m => m.Nombre == "ElPozo").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = elPozoId, CertificacionId = certs["ISO 20400"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = elPozoId, CertificacionId = certs["Lean&Green 2 estrellas"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = elPozoId, CertificacionId = certs["MERCO ESG Top 100"].Id });

            // Campofrío
            var campofríoId = marcas.First(m => m.Nombre == "Campofrío").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = campofríoId, CertificacionId = certs["ISO 20400"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = campofríoId, CertificacionId = certs["ISO 14001"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = campofríoId, CertificacionId = certs["EFR Empresa Familiarmente Responsable"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = campofríoId, CertificacionId = certs["Welfair Bienestar Animal"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = campofríoId, CertificacionId = certs["Reducción 83% siniestralidad laboral"].Id });

            // Danone
            var danoneId = marcas.First(m => m.Nombre == "Danone").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = danoneId, CertificacionId = certs["ISO 14001"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = danoneId, CertificacionId = certs["B Corp Certified"].Id });

            // Nestlé
            var nestleId = marcas.First(m => m.Nombre == "Nestlé").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = nestleId, CertificacionId = certs["ISO 14001"].Id });

            // Central Lechera Asturiana
            var claId = marcas.First(m => m.Nombre == "Central Lechera Asturiana").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = claId, CertificacionId = certs["ISO 14001"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = claId, CertificacionId = certs["Denominación de Origen Asturiana"].Id });

            // Pescanova
            var pescanovaId = marcas.First(m => m.Nombre == "Pescanova").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = pescanovaId, CertificacionId = certs["ISO 14001"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = pescanovaId, CertificacionId = certs["MSC Marine Stewardship Council"].Id });

            // Gullón
            var gullonId = marcas.First(m => m.Nombre == "Gullón").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = gullonId, CertificacionId = certs["Pacto Mundial ONU"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = gullonId, CertificacionId = certs["MERCO ESG Top 10"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = gullonId, CertificacionId = certs["Plan Igualdad Paritario Verificado"].Id });

            // Mahou
            var mahouId = marcas.First(m => m.Nombre == "Mahou").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = mahouId, CertificacionId = certs["ISO 14001"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = mahouId, CertificacionId = certs["Empresa Saludable AENOR"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = mahouId, CertificacionId = certs["Pacto Mundial ONU"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = mahouId, CertificacionId = certs["MERCO ESG 6º lugar 2024"].Id });

            // Estrella Galicia
            var estrellaGaliciaId = marcas.First(m => m.Nombre == "Estrella Galicia").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = estrellaGaliciaId, CertificacionId = certs["B Corp Certified"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = estrellaGaliciaId, CertificacionId = certs["Zero Waste Certification"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = estrellaGaliciaId, CertificacionId = certs["FSC/PEFC"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = estrellaGaliciaId, CertificacionId = certs["Economía Circular Verificada"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = estrellaGaliciaId, CertificacionId = certs["Aluminio 100% Reciclable"].Id });

            // Calvo
            var calvoId = marcas.First(m => m.Nombre == "Calvo").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = calvoId, CertificacionId = certs["ISO 14001"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = calvoId, CertificacionId = certs["MSC Marine Stewardship Council"].Id });

            // Alpro
            var alproId = marcas.First(m => m.Nombre == "Alpro").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = alproId, CertificacionId = certs["ISO 14001"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = alproId, CertificacionId = certs["Sustainable Sourcing Verified"].Id });

            // Eroski
            var erokskiId = marcas.First(m => m.Nombre == "Eroski").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = erokskiId, CertificacionId = certs["MSC Marine Stewardship Council"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = erokskiId, CertificacionId = certs["Pacto Mundial ONU"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = erokskiId, CertificacionId = certs["MERCO ESG Top 10"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = erokskiId, CertificacionId = certs["Plan Igualdad Paritario Verificado"].Id });

            // Alimerka
            var alimerkaId = marcas.First(m => m.Nombre == "Alimerka").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = alimerkaId, CertificacionId = certs["ISO 14001"].Id });

            // Gadis
            var gadisId = marcas.First(m => m.Nombre == "Gadis").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = gadisId, CertificacionId = certs["ISO 14001"].Id });
            relaciones.Add(new EmpresaCertificacion { MarcaId = gadisId, CertificacionId = certs["MERCO ESG Top 10"].Id });

            // Hipercor
            var hipercorId = marcas.First(m => m.Nombre == "Hipercor").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = hipercorId, CertificacionId = certs["ISO 14001"].Id });

            // El Corte Inglés
            var elCorteInglesId = marcas.First(m => m.Nombre == "El Corte Inglés").Id;
            relaciones.Add(new EmpresaCertificacion { MarcaId = elCorteInglesId, CertificacionId = certs["ISO 14001"].Id });

            _context.EmpresaCertificacion.AddRange(relaciones);
            await _context.SaveChangesAsync();

        }
    }
}
