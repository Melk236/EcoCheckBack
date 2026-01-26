using System.Security.Claims;
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
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        //Obtenemos el usuario con el claim name del JWT.

        [Authorize]//Le dice al pipeline useAuhorization que le pase los claims a la clase User
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            Console.WriteLine("Hola mundo"+User.FindFirst(ClaimTypes.Name)?.Value);
            Console.WriteLine(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var usuario = await _profileService.GetUserByToken(User.FindFirst(ClaimTypes.Name)?.Value);
            
            return Ok(usuario);
        }
    }
}
