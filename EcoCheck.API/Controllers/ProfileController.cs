using System.Security.Claims;
using EcoCheck.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoCheck.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController:ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        //Obtenemos el usuario con el claim name del JWT.

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var usuario = await _profileService.GetUserByToken(User.FindFirst(ClaimTypes.Name).Value);

            return Ok(usuario);
        }
    }
}
