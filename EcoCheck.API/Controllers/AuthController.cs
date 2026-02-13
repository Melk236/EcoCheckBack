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
        private readonly IUserService _userService;
        public AuthController(IAuthService authService,IJwtService jwtService, IUserService userService)
        {
            _authService = authService;
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var usuario=await _authService.CheckUser(dto);//No devolvemos nada ya que si algo es inválido se lanza una excepción
            var rol = await _userService.GetRoleByUserAsync(usuario);

            var token = _jwtService.GenerateToken(usuario,rol);

            return Ok(new { token });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] LoginDto dto)
        {
            var usuario= await _authService.CreateUser(dto);
            var rol = await _userService.GetRoleByUserAsync(usuario);

            var token = _jwtService.GenerateToken(usuario,rol);

            return Ok(new { token });
        }
    }
}
