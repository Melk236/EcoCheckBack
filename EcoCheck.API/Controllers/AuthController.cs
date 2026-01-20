using EcoCheck.Application.Dtos;
using EcoCheck.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:Controller
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;
        public AuthController(IAuthService authService,IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var usuario=await _authService.CheckUser(dto);//No devolvemos nada ya que si algo es inválido se lanza una excepción
            var token = _jwtService.GenerateToken(usuario);

            return Ok(new {token});
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] LoginDto dto)
        {
            var usuario= await _authService.CreateUser(dto);
            var token = _jwtService.GenerateToken(usuario);

            return Ok(new { token });
        }
    }
}
