using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.API.Controllers
{
    [ApiController]  
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _userService.GetAllUsers();

            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var usuario = await _userService.GetUserById(id);

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(int id, [FromForm] UpdateUserDto dto)
        {
            Console.WriteLine(id);
            var usuario=await _userService.UpdateUser(id, dto);

            return Ok(usuario);
        }
        [HttpPatch("{id}/ChangePassword")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordDto dto)
        {
               await _userService.ChangePasswordAsync(id, dto);

               return Ok(new {message="Operación realizada correctamente"});
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);

            return NoContent();
        }
    }
}
