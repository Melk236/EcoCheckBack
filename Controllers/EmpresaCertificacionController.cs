using EcoCheck.Dtos.CreateDtos;
using EcoCheck.Dtos.UpdateDtos;
using EcoCheck.Models;
using EcoCheck.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaCertificacionController:ControllerBase
    {
        public readonly EmpresaCertificacionService _empresaCertificacionService;

        public EmpresaCertificacionController(EmpresaCertificacionService empresaCertificacionService)
        {
            _empresaCertificacionService = empresaCertificacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empresaCertificacion=await _empresaCertificacionService.GetAll();

            return Ok(empresaCertificacion);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empresaCertificacion = await _empresaCertificacionService.GetById(id);

            return Ok(empresaCertificacion);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateEmpresaCertificacionDto[] dto)
        {
            var empresaCertificaciones=await _empresaCertificacionService.Create(dto);


            return Created(string.Empty, empresaCertificaciones);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] UpdateEmpresaCertificacionDto dto)
        {
            var empresaCertificacion=await _empresaCertificacionService.Update(id,dto);

            return Ok(empresaCertificacion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _empresaCertificacionService.Delete(id);

            return NoContent();
        }
    }
}
