using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuntuacionController : ControllerBase
    {
        private readonly IPuntuacionService _puntuacionService;

        public PuntuacionController(IPuntuacionService puntuacionService)
        {
            _puntuacionService = puntuacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPuntuaciones()
        {
            var puntuaciones = await _puntuacionService.GetAllPuntuaciones();

            return Ok(puntuaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPuntuacionById(int id)
        {
            var puntuacion=await _puntuacionService.GetPuntuacionById(id);

            return Ok(puntuacion);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPuntuacion([FromBody] CreatePuntuacionDto dto)
        {
            var puntuacion = await _puntuacionService.CrearPuntuacion(dto);
            var url = $"api/puntuacion/{puntuacion.Id}";
            return Created(url, puntuacion);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPuntuacion(int id, [FromBody] UpdatePuntuacionDto dto)
        {
            var puntuacion = await _puntuacionService.ActualizarPuntuacion(id,dto);

            return Ok(puntuacion);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> ElminarPuntuacion(int id)
        {
            await _puntuacionService.EliminarPuntuacion(id);

            return NoContent();

        }
    }
}
