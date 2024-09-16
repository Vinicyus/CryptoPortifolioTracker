namespace CryptoPortfolioTracker.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Portfolio> Portfolios { get; set; }
        public ICollection<Alert> Alerts { get; set; }
    }
}
