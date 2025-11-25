using EcoCheck.Dtos.CreateDtos;
using EcoCheck.Dtos.UpdateDtos;
using EcoCheck.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController:ControllerBase
    {
        private readonly MaterialService _materialService;

        public MaterialController(MaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMateriales()
        {
            var materiales = await _materialService.GetAllMaterial();

            return Ok(materiales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterialesByProductoId(int id)
        {
            var materiales = await _materialService.GetMaterialById(id);

            return Ok(materiales);  
        }

        [HttpPost]
        public async Task<IActionResult> CrearMateriales([FromBody] CreateMaterialDto[] dto)
        {
            var materiales = await _materialService.CrearMaterial(dto);
            var url = $"api/material/" + dto[0].ProductoId;

            return Created(url,materiales);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMateriales(int id, [FromBody] UpdateMaterialDto dto)
        {
            var material = await _materialService.ActualizarMaterial(id,dto);

            return Ok(material);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarMaterial(int id)
        {
            await _materialService.EliminarMaterial(id);

            return NoContent();
        }
    }
}
