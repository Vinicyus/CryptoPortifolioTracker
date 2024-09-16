namespace CryptoPortfolioTracker.API.Models
{
    public class PortfolioHolding
    {
        public int HoldingId { get; set; }
        public int PortfolioId { get; set; }
        public int CryptoId { get; set; }
        public decimal Amount { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Portfolio Portfolio { get; set; }
        public Cryptocurrency Cryptocurrency { get; set; }
    }
}
