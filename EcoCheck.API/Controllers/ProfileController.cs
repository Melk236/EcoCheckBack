using EcoCheck.API.Middleware;
using System.Security.Claims;
using EcoCheck.Application.Dtos;
using EcoCheck.Application.Dtos.UpdateDtos;
using EcoCheck.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.API.Controllers
{
    [ApiController]
    [RateLimit(60, 60)]
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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
          
            var usuario = await _profileService.GetUserByToken(User.FindFirst(ClaimTypes.Name)?.Value);
            return Ok(usuario);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateUserDto dto)
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var usuario = await _userService.UpdateUser(int.Parse(id),dto);

            return Ok(usuario);

        }

        [Authorize]
        [HttpPatch("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _userService.ChangePasswordAsync(int.Parse(id), dto);

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteProfileAsync()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _userService.DeleteUser(int.Parse(id));

            return Ok();
        }

    }
}
