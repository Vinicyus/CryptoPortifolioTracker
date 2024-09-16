// Controllers/PortfoliosController.cs
using AutoMapper;
using CryptoPortfolioTracker.API.Data;
using CryptoPortfolioTracker.API.DTOs;
using CryptoPortfolioTracker.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CryptoPortfolioTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PortfoliosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PortfoliosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all portfolios for the authenticated user.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUserPortfolios()
        {
            var userId = GetUserId();
            var portfolios = await _context.Portfolios
                .Include(p => p.Holdings)
                    .ThenInclude(h => h.Cryptocurrency)
                .Where(p => p.UserId == userId)
                .ToListAsync();

            var portfolioDtos = _mapper.Map<IEnumerable<PortfolioDTO>>(portfolios);
            return Ok(portfolioDtos);
        }

        /// <summary>
        /// Creates a new portfolio for the authenticated user.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreatePortfolio(CreatePortfolioDTO dto)
        {
            var userId = GetUserId();
            var portfolio = new Portfolio
            {
                UserId = userId,
                Name = dto.Name,
                CreatedAt = DateTime.UtcNow
            };

            _context.Portfolios.Add(portfolio);
            await _context.SaveChangesAsync();

            var portfolioDto = _mapper.Map<PortfolioDTO>(portfolio);
            return Ok(portfolioDto);
        }

        // Additional CRUD endpoints (Update, Delete) can be implemented similarly

        #region Helper Methods

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue("id"));
        }

        #endregion
    }
}
