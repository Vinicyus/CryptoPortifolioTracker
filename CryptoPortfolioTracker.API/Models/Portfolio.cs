namespace CryptoPortfolioTracker.API.Models
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public ICollection<PortfolioHolding> Holdings { get; set; }
    }
}
