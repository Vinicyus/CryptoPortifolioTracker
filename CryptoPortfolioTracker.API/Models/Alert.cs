namespace CryptoPortfolioTracker.API.Models
{
    public class Alert
    {
        public int AlertId { get; set; }
        public int UserId { get; set; }
        public int CryptoId { get; set; }
        public decimal PriceThreshold { get; set; }
        public bool IsAbove { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public Cryptocurrency Cryptocurrency { get; set; }
    }
}
