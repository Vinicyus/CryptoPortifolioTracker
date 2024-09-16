using System;
using System.Collections.Generic;

namespace CryptoPortfolioTracker.API.DTOs
{
    public class PortfolioDTO
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<PortfolioHoldingDTO> Holdings { get; set; }
    }
}