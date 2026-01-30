using EcoCheck.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoCheck.Infrastructure.Data.Seeders
{
    public class CertificacionSeeder
    {
        private readonly AppDbContext _context;
        public CertificacionSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedCertificaciones()
        {

            if (await _context.Certificaciones.AnyAsync())
            {
                return;
            }

            var certificaciones = new List<Certificacion>
            {
                 new Certificacion { Nombre = "ISO 14001", Descripcion = "Sistema de Gestión Ambiental. Certifica que la empresa cuenta con procesos para minimizar impacto ambiental." },
                new Certificacion { Nombre = "ISO 20400", Descripcion = "Compras Sostenibles. Verifica que la empresa implementa prácticas de compra responsable y sostenible." },
                new Certificacion { Nombre = "Fair Trade", Descripcion = "Comercio Justo. Certifica relaciones comerciales equitativas y precios justos para productores." },
                new Certificacion { Nombre = "B Corp Certified", Descripcion = "Empresa Certificada B. Verifica que la empresa equilibra propósito y ganancias, con impacto social positivo." },
                new Certificacion { Nombre = "Rainforest Alliance", Descripcion = "Alianza para Bosques Tropicales. Certifica prácticas sostenibles en agricultura y conservación de ecosistemas." },
                new Certificacion { Nombre = "Utz Certified", Descripcion = "Certificación de Café/Cacao Ético. Verifica prácticas sostenibles y equitativas en producción de café y cacao." },
                 new Certificacion { Nombre = "SA8000", Descripcion = "Responsabilidad Social en Trabajo. Certifica cumplimiento de derechos laborales y condiciones de trabajo dignas." },
                new Certificacion { Nombre = "MSC Marine Stewardship Council", Descripcion = "Pesca Sostenible. Certifica que los productos del mar provienen de pesca responsable y controlada." },
                new Certificacion { Nombre = "FSC/PEFC", Descripcion = "Bosques Sostenibles. Verifica que la madera y papel provienen de bosques gestionados responsablemente." },
                new Certificacion { Nombre = "Pacto Mundial ONU", Descripcion = "Compromiso Global de la ONU. Empresa adherida a principios de derechos humanos, trabajo, ambiente y anticorrupción." },
                new Certificacion { Nombre = "MERCO ESG Top 10", Descripcion = "Monitor Empresarial de Reputación Corporativa. Top 10 en España en criterios ESG (Ambiental, Social, Gobernanza)." },
                new Certificacion { Nombre = "MERCO ESG 6º lugar 2024", Descripcion = "Ranking MERCO 2024. Empresa clasificada en el 6º lugar en España en criterios de sostenibilidad ESG." },
                new Certificacion { Nombre = "MERCO ESG Top 100", Descripcion = "Ranking MERCO. Empresa incluida en top 100 de España en criterios ESG de responsabilidad corporativa." },
                new Certificacion { Nombre = "Empresa Saludable AENOR", Descripcion = "Certificación de Salud Laboral. Verifica gestión de salud y seguridad en el trabajo de alta calidad." },
                new Certificacion { Nombre = "EFR Empresa Familiarmente Responsable", Descripcion = "Responsabilidad Familiar. Certifica políticas que concilian vida laboral y familiar de los empleados." },
                new Certificacion { Nombre = "Plan Igualdad Paritario Verificado", Descripcion = "Igualdad de Género. Verifica plan documentado de igualdad entre hombres y mujeres en la empresa." },
                new Certificacion { Nombre = "Welfair Bienestar Animal", Descripcion = "Bienestar Animal. Certifica prácticas de cuidado y trato ético de animales en cadena de suministro." },
                new Certificacion { Nombre = "Lean&Green 2 estrellas", Descripcion = "Logística Sostenible. Certifica reducción de emisiones en logística con 2 estrellas de excelencia." },
                new Certificacion { Nombre = "Denominación de Origen Asturiana", Descripcion = "Sello Geográfico. Producto originario de Asturias con métodos tradicionales y calidad verificada." },
                new Certificacion { Nombre = "Zero Waste Certification", Descripcion = "Cero Residuos. Certifica que la empresa desvía 90%+ de residuos de vertederos mediante reciclaje." },
                new Certificacion { Nombre = "Economía Circular Verificada", Descripcion = "Economía Circular. Verifica que la empresa implementa modelos de reutilización y reciclaje de recursos." },
                new Certificacion { Nombre = "Aluminio 100% Reciclable", Descripcion = "Empaques Sostenibles. Certifica que los empaques de aluminio son 100% reciclables indefinidamente." },
                new Certificacion { Nombre = "Nutri-Score implementado", Descripcion = "Etiquetado Nutricional. Producto etiquetado con Nutri-Score para ayudar a elegir alimentos más saludables." },
                new Certificacion { Nombre = "Planet-Score", Descripcion = "Impacto Ambiental de Alimentos. Puntuación de impacto ambiental (agua, emisiones, biodiversidad) del producto." },
                new Certificacion { Nombre = "Ecoetiquetado FSC/PEFC", Descripcion = "Papel y Cartón Sostenible. Materiales de packaging de fuentes forestales responsables certificadas." },
                new Certificacion { Nombre = "Reducción 83% siniestralidad laboral", Descripcion = "Seguridad Laboral. Empresa ha reducido accidentes laborales en un 83% con políticas de prevención." },
                new Certificacion { Nombre = "Sustainable Sourcing Verified", Descripcion = "Abastecimiento Sostenible. Verifica que proveedores cumplen criterios ambientales y sociales certificados." },
                new Certificacion { Nombre = "ISO 50001", Descripcion = "Sistema de Gestión Energética. Certifica que la empresa optimiza el uso energético y reduce el consumo." },
                new Certificacion { Nombre = "SBTi (Science Based Targets initiative)", Descripcion = "Objetivos Basados en la Ciencia. Compromisos verificados de reducción de emisiones alineados con el Acuerdo de París." },
                new Certificacion { Nombre = "CHEP Sustainability Certificate", Descripcion = "Certificación de Sostenibilidad CHEP. Verifica prácticas sostenibles en logística y gestión de palets." },
                new Certificacion { Nombre = "Ecovadis Platinum", Descripcion = "Evaluación de Sostenibilidad Ecovadis. Nivel más alto en evaluación de prácticas ambientales, sociales y éticas." },
                new Certificacion { Nombre = "AENOR Buen Gobierno Corporativo (G++)", Descripcion = "Buen Gobierno Corporativo. Certifica prácticas de transparencia, ética y buen gobierno empresarial." },
                new Certificacion { Nombre = "CSRD aligned", Descripcion = "Corporate Sustainability Reporting Directive. Empresa alineada con directivas de reporte de sostenibilidad europeo." },
                new Certificacion { Nombre = "EPD", Descripcion = "Environmental Product Declaration. Declaración ambiental de producto con análisis de ciclo de vida verificado." },
                new Certificacion { Nombre = "Zero Waste to Landfill", Descripcion = "Cero Residuos a Vertedero. Certifica que la empresa evita enviar residuos a vertederos mediante reciclaje y reutilización." },
                new Certificacion { Nombre = "RSPO", Descripcion = "Roundtable on Sustainable Palm Oil. Certifica aceite de palma producido de manera sostenible sin deforestación." },
                new Certificacion { Nombre = "Cocoa Life", Descripcion = "Cacao Sostenible. Programa que promueve prácticas sostenibles en el cultivo de cacao." },
                new Certificacion { Nombre = "Harmony wheat", Descripcion = "Trigo Sostenible Harmony. Certifica trigo cultivado con prácticas agrícolas sostenibles." },
                new Certificacion { Nombre = "EU Ecolabel", Descripcion = "Etiqueta Ecológica Europea. Certifica productos con menor impacto ambiental en todo su ciclo de vida." },
                new Certificacion { Nombre = "EcoVadis Gold", Descripcion = "Evaluación de Sostenibilidad Ecovadis. Nivel alto en evaluación de prácticas ambientales, sociales y éticas." },
                new Certificacion { Nombre = "Alliance for Water Stewardship", Descripcion = "Administración del Agua. Certifica gestión sostenible y responsable de los recursos hídricos." },
                new Certificacion { Nombre = "Organic", Descripcion = "Agricultura Orgánica. Certifica que los productos son cultivados sin pesticidas sintéticos, fertilizantes químicos ni organismos modificados genéticamente." },
                new Certificacion { Nombre = "Integrated Production", Descripcion = "Producción Integrada. Certifica métodos agrícolas que combinan técnicas sostenibles con el uso controlado de recursos para minimizar el impacto ambiental." }
            };
            _context.Certificaciones.AddRange(certificaciones);
            await _context.SaveChangesAsync();

        }
    }
}
