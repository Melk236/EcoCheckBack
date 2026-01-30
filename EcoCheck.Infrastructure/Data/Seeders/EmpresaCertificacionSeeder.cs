using EcoCheck.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoCheck.Infrastructure.Data.Seeders
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

             // La Campesina
             var laCampesinaId = marcas.First(m => m.Nombre == "La Campesina").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = laCampesinaId, CertificacionId = certs["ISO 14001"].Id });



             // Président Petit
             var presidentPetitId = marcas.First(m => m.Nombre == "Président Petit").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = presidentPetitId, CertificacionId = certs["ISO 14001"].Id });

             // Nuevas relaciones basadas en certificaciones del MarcaSeeder
             // President
             var presidentId = marcas.First(m => m.Nombre == "President").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = presidentId, CertificacionId = certs["ISO 14001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = presidentId, CertificacionId = certs["ISO 50001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = presidentId, CertificacionId = certs["SBTi (Science Based Targets initiative)"].Id });

             // García Baquero
             var garciaBaqueroId = marcas.First(m => m.Nombre == "García Baquero").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = garciaBaqueroId, CertificacionId = certs["CHEP Sustainability Certificate"].Id });

             // El Caserío
             var elCaserioId = marcas.First(m => m.Nombre == "El Caserío").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = elCaserioId, CertificacionId = certs["ISO 14001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = elCaserioId, CertificacionId = certs["ISO 50001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = elCaserioId, CertificacionId = certs["SBTi (Science Based Targets initiative)"].Id });

             // Reny Picot
             var renyPicotId = marcas.First(m => m.Nombre == "Reny Picot").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = renyPicotId, CertificacionId = certs["ISO 14001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = renyPicotId, CertificacionId = certs["ISO 50001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = renyPicotId, CertificacionId = certs["SBTi (Science Based Targets initiative)"].Id });

             // Carbonell
             var carbonellId = marcas.First(m => m.Nombre == "Carbonell").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = carbonellId, CertificacionId = certs["Ecovadis Platinum"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = carbonellId, CertificacionId = certs["AENOR Buen Gobierno Corporativo (G++)"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = carbonellId, CertificacionId = certs["CSRD aligned"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = carbonellId, CertificacionId = certs["EPD"].Id });

             // Koipe
             var koipeId = marcas.First(m => m.Nombre == "Koipe").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = koipeId, CertificacionId = certs["Ecovadis Platinum"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = koipeId, CertificacionId = certs["AENOR Buen Gobierno Corporativo (G++)"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = koipeId, CertificacionId = certs["CSRD aligned"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = koipeId, CertificacionId = certs["EPD"].Id });

             // Gigante Verde
             var giganteVerdeId = marcas.First(m => m.Nombre == "Gigante Verde").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = giganteVerdeId, CertificacionId = certs["Zero Waste to Landfill"].Id });

             // Heinz
             var heinzId = marcas.First(m => m.Nombre == "Heinz").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = heinzId, CertificacionId = certs["SBTi (Science Based Targets initiative)"].Id });

             // Hellmann's
             var hellmannsId = marcas.First(m => m.Nombre == "Hellmann's").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = hellmannsId, CertificacionId = certs["ISO 14001"].Id });

             // Litoral
             var litoralId = marcas.First(m => m.Nombre == "Litoral").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = litoralId, CertificacionId = certs["ISO 14001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = litoralId, CertificacionId = certs["ISO 50001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = litoralId, CertificacionId = certs["SBTi (Science Based Targets initiative)"].Id });

             // Cidacos
             var cidacosId = marcas.First(m => m.Nombre == "Cidacos").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = cidacosId, CertificacionId = certs["ISO 14001"].Id });

             // Bonduelle
             var bonduelleId = marcas.First(m => m.Nombre == "Bonduelle").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = bonduelleId, CertificacionId = certs["B Corp Certified"].Id });

             // Oscar Mayer
             var oscarMayerId = marcas.First(m => m.Nombre == "Oscar Mayer").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = oscarMayerId, CertificacionId = certs["SBTi (Science Based Targets initiative)"].Id });

             // Fontaneda
             var fontanedaId = marcas.First(m => m.Nombre == "Fontaneda").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = fontanedaId, CertificacionId = certs["RSPO"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = fontanedaId, CertificacionId = certs["Cocoa Life"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = fontanedaId, CertificacionId = certs["Harmony wheat"].Id });

             // Tosta Rica
             var tostaRicaId = marcas.First(m => m.Nombre == "Tosta Rica").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = tostaRicaId, CertificacionId = certs["ISO 14001"].Id });

             // Kellogg's
             var kelloggsId = marcas.First(m => m.Nombre == "Kellogg's").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = kelloggsId, CertificacionId = certs["SBTi (Science Based Targets initiative)"].Id });

             // Nestlé Cereales
             var nestleCerealesId = marcas.First(m => m.Nombre == "Nestlé Cereales").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = nestleCerealesId, CertificacionId = certs["ISO 14001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = nestleCerealesId, CertificacionId = certs["Alliance for Water Stewardship"].Id });

             // Pringles
             var pringlesId = marcas.First(m => m.Nombre == "Pringles").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = pringlesId, CertificacionId = certs["SBTi (Science Based Targets initiative)"].Id });

             // Ferrero
             var ferreroId = marcas.First(m => m.Nombre == "Ferrero").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = ferreroId, CertificacionId = certs["RSPO"].Id });

             // Lindt
             var lindtId = marcas.First(m => m.Nombre == "Lindt").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = lindtId, CertificacionId = certs["RSPO"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = lindtId, CertificacionId = certs["FSC/PEFC"].Id });

             // Milka
             var milkaId = marcas.First(m => m.Nombre == "Milka").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = milkaId, CertificacionId = certs["RSPO"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = milkaId, CertificacionId = certs["Cocoa Life"].Id });

             // Chupa Chups
             var chupaChupsId = marcas.First(m => m.Nombre == "Chupa Chups").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = chupaChupsId, CertificacionId = certs["ISO 14001"].Id });

             // Trina
             var trinaId = marcas.First(m => m.Nombre == "Trina").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = trinaId, CertificacionId = certs["ISO 14001"].Id });

             // Minute Maid
             var minuteMaidId = marcas.First(m => m.Nombre == "Minute Maid").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = minuteMaidId, CertificacionId = certs["ISO 14001"].Id });

             // Nestea
             var nesteaId = marcas.First(m => m.Nombre == "Nestea").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = nesteaId, CertificacionId = certs["ISO 14001"].Id });

             // Font Vella
             var fontVellaId = marcas.First(m => m.Nombre == "Font Vella").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = fontVellaId, CertificacionId = certs["B Corp Certified"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = fontVellaId, CertificacionId = certs["ISO 14001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = fontVellaId, CertificacionId = certs["Zero Waste Certification"].Id });

             // Lanjarón
             var lanjaronId = marcas.First(m => m.Nombre == "Lanjarón").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = lanjaronId, CertificacionId = certs["B Corp Certified"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = lanjaronId, CertificacionId = certs["ISO 14001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = lanjaronId, CertificacionId = certs["Zero Waste Certification"].Id });

             // Vichy Catalan
             var vichyCatalanId = marcas.First(m => m.Nombre == "Vichy Catalan").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = vichyCatalanId, CertificacionId = certs["ISO 14001"].Id });

             // Skip
             var skipId = marcas.First(m => m.Nombre == "Skip").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = skipId, CertificacionId = certs["ISO 14001"].Id });

             // Mimosín
             var mimosinId = marcas.First(m => m.Nombre == "Mimosín").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = mimosinId, CertificacionId = certs["ISO 14001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = mimosinId, CertificacionId = certs["EcoVadis Gold"].Id });

             // Dixan
             var dixanId = marcas.First(m => m.Nombre == "Dixan").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = dixanId, CertificacionId = certs["ISO 14001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = dixanId, CertificacionId = certs["EcoVadis Gold"].Id });

             // Don Limpio
             var donLimpioId = marcas.First(m => m.Nombre == "Don Limpio").Id;
             relaciones.Add(new EmpresaCertificacion { MarcaId = donLimpioId, CertificacionId = certs["ISO 14001"].Id });
             relaciones.Add(new EmpresaCertificacion { MarcaId = donLimpioId, CertificacionId = certs["Zero Waste to Landfill"].Id });

              // KH-7
              var kh7Id = marcas.First(m => m.Nombre == "KH-7").Id;
              relaciones.Add(new EmpresaCertificacion { MarcaId = kh7Id, CertificacionId = certs["ISO 14001"].Id });
              relaciones.Add(new EmpresaCertificacion { MarcaId = kh7Id, CertificacionId = certs["EU Ecolabel"].Id });

              // Mister Choc
              var misterChocId = marcas.First(m => m.Nombre == "Mister Choc").Id;
              relaciones.Add(new EmpresaCertificacion { MarcaId = misterChocId, CertificacionId = certs["Fair Trade"].Id });
              relaciones.Add(new EmpresaCertificacion { MarcaId = misterChocId, CertificacionId = certs["Rainforest Alliance"].Id });
              relaciones.Add(new EmpresaCertificacion { MarcaId = misterChocId, CertificacionId = certs["Organic"].Id });

              // Abril
              var abrilId = marcas.First(m => m.Nombre == "Abril").Id;
              relaciones.Add(new EmpresaCertificacion { MarcaId = abrilId, CertificacionId = certs["ISO 14001"].Id });
              relaciones.Add(new EmpresaCertificacion { MarcaId = abrilId, CertificacionId = certs["Integrated Production"].Id });

              // Agrícola Villena
              var agricolaVillenaId = marcas.First(m => m.Nombre == "Agrícola Villena").Id;
              relaciones.Add(new EmpresaCertificacion { MarcaId = agricolaVillenaId, CertificacionId = certs["ISO 14001"].Id });

              _context.EmpresaCertificacion.AddRange(relaciones);
            await _context.SaveChangesAsync();

        }
    }
}
