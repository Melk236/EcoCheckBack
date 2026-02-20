
using EcoCheck.Application.Dtos.CreateDtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.Api.Controllers
{
    [ApiController]
   
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        public readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService) {
            _productoService = productoService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get() {

            var productos = await _productoService.GetAllProductos();

            return Ok(productos);

        }
        [HttpGet("Comparativa")]
        [Authorize]
        public async Task<IActionResult> GetProductosComparativa([FromQuery] string[] categoria,[FromQuery] float nota)
        {
            var productos = await _productoService.GetProductosComparacion(categoria, nota);

            return Ok(productos);
        
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.GetProductoById(id);
            return Ok(producto);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CrearProducto([FromBody] CreateProductoDto dto)
        {
            var producto=await _productoService.CreateProducto(dto);
            var url = $"/api/producto/{producto.Id}";
            return Created(url, producto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> ActualizarProducto(int id, [FromBody] UpdateProductoDto dto)
        {
            var producto=await _productoService.UpdateProducto(id,dto);
            return Ok(producto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            await _productoService.EliminarProducto(id);
            return NoContent();
        }

    }
}
