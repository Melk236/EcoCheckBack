
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCheck.Domain.Entities
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        
        public string Token { get; set; }
        
        public int UserId { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
