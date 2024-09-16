using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolioTracker.API.DTOs
{
    public class CreatePortfolioDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
    }
}