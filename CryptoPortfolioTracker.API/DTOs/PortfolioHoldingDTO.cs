using System;

namespace CryptoPortfolioTracker.API.DTOs
{
    public class PortfolioHoldingDTO
    {
        public int HoldingId { get; set; }
        public string CryptoSymbol { get; set; }
        public decimal Amount { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}