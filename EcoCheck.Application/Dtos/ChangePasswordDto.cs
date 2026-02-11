

using System.ComponentModel.DataAnnotations;

namespace EcoCheck.Application.Dtos
{
    public class ChangePasswordDto
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string NewPassword { get; set; }

    }
}
