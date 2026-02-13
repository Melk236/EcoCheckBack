using System.Security.Claims;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController:ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;
        public ProfileController(IProfileService profileService, IUserService userService)
        {
            _profileService = profileService;
            _userService = userService;
        }
        //Obtenemos el usuario con el claim name del JWT.

        [Authorize]//Le dice al pipeline useAuhorization que le pase los claims a la clase User
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
         
            var usuario = await _profileService.GetUserByToken(User.FindFirst(ClaimTypes.Name)?.Value);
            return Ok(usuario);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateUserDto dto)
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var usuario = await _userService.UpdateUser(int.Parse(id),dto);

            return Ok(usuario);

        }

        [HttpPatch("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _userService.ChangePasswordAsync(int.Parse(id), dto);

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteProfileAsync()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _userService.DeleteUser(int.Parse(id));

            return Ok();
        }

    }
}
