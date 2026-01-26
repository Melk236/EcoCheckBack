using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController:ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMarcas()
        {
            var marcas=await _marcaService.GetAllMarcas();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarcaById(int id)
        {
            var marca=await _marcaService.GetMarcaById(id);
            return Ok(marca);
        }

        [HttpPost]
        public async Task<IActionResult> CrearMarca([FromBody] CreateMarcaDto dto)
        {
            var marca = await _marcaService.CrearMarca(dto);
            var url = $"/api/marca/{marca.Id}";
            return Created(url, marca);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMarca(int id,UpdateMarcaDto dto)
        {
            var marca = await _marcaService.ActualizarMarca(id,dto);
            return Ok(marca);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> BorrarMarca(int id)
        {
            await _marcaService.BorrarMarca(id);
            return NoContent();
        }
    }
}
