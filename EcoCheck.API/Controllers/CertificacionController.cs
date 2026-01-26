using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificacionController:ControllerBase
    {

        private readonly ICertificacionService _certificacionService;

        public CertificacionController(ICertificacionService certificacionService)
        {
            _certificacionService = certificacionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var certficaciones = await _certificacionService.GetAllCertificaciones();
            return Ok(certficaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var certificacion = await _certificacionService.GetCertificacionById(id);
            return Ok(certificacion);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCertificacionDto[] dto)
        {
            var certficaciones = await _certificacionService.CreateCerticacion(dto);
            return Created(string.Empty, dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _certificacionService.DeleteCertificacion(id);
            return NoContent();
        }
    }
}
