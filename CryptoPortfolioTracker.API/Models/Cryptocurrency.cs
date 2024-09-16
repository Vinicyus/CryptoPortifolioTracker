namespace CryptoPortfolioTracker.API.Models
{
    public class Cryptocurrency
    {
        public int CryptoId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
