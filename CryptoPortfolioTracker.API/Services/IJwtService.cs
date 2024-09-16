using CryptoPortfolioTracker.API.Models;

namespace CryptoPortfolioTracker.API.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}