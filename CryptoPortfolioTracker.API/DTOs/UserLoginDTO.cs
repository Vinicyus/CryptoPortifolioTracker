using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolioTracker.API.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}