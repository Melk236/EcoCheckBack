using EcoCheck.Application.Dtos;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
            var usuario=await _authService.CheckUser(dto);
            var rol = await _userService.GetRoleByUserAsync(usuario);

            var token = _jwtService.GenerateToken(usuario,rol);
            var refreshToken=await _jwtService.GenerateRefreshTokenAsync(usuario.Id);

            var tokenResponse = new TokenResponseDto
            {
                RefreshToken = refreshToken,
                Token = token
            };

            Response.Cookies.Append("refreshToken", tokenResponse.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Lax,
                Expires = DateTime.UtcNow.AddDays(7),
                Domain = "localhost"  
            });


            return Ok(new { token=tokenResponse.Token });
        }

        [HttpPost("Register")]
       
        public async Task<IActionResult> Register([FromBody] LoginDto dto)
        {
            var usuario= await _authService.CreateUser(dto);
            var rol = await _userService.GetRoleByUserAsync(usuario);

            var token = _jwtService.GenerateToken(usuario,rol);
            var refreshToken = await _jwtService.GenerateRefreshTokenAsync(usuario.Id);

            

            var tokenResponse = new TokenResponseDto
            {
                Token =token,
                RefreshToken=refreshToken
            };

            Response.Cookies.Append("refreshToken", tokenResponse.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Lax,
                Expires = DateTime.UtcNow.AddDays(7),
                Domain = "localhost"  // ← sin puerto, así la comparten ambos
            });

            return Ok(new {token = tokenResponse.Token });
        }

        [HttpPost("Refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            
            

            if (refreshToken is null) return Unauthorized(new { mensaje = "No se encontró la cookie refreshToken" });

            var tokenResponse = await _jwtService.RefreshAsync(refreshToken);

            Response.Cookies.Append("refreshToken", tokenResponse.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Lax,
                Expires = DateTime.UtcNow.AddDays(7),
                Domain = "localhost"  // ← sin puerto, así la comparten ambos
            });

            return Ok(new { token=tokenResponse.Token });
        }

        [HttpPost("LogOut")]

        public async Task<IActionResult> LogOut()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (refreshToken is null) return Unauthorized(new { mensaje = "No se encontró la cookie refreshToken" });

            await _jwtService.LogOutAsync(refreshToken);

            return Ok();
        }

    }
}
