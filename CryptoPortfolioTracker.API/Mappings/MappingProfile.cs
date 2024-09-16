namespace CryptoPortfolioTracker.API.Mappings
{
    using AutoMapper;
    using CryptoPortfolioTracker.API.Models;
    using CryptoPortfolioTracker.API.DTOs;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Portfolio, PortfolioDTO>();
            CreateMap<PortfolioHolding, PortfolioHoldingDTO>()
                .ForMember(dest => dest.CryptoSymbol, opt => opt.MapFrom(src => src.Cryptocurrency.Symbol));
            // Additional mappings...
        }
    }
}
