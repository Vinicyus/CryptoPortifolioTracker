// Data/ApplicationDbContext.cs
using CryptoPortfolioTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoPortfolioTracker.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for each model
        public DbSet<User> Users { get; set; }
        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioHolding> PortfolioHoldings { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explicitly define primary keys
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Cryptocurrency>()
                .HasKey(c => c.CryptoId);

            modelBuilder.Entity<Portfolio>()
                .HasKey(p => p.PortfolioId);

            modelBuilder.Entity<PortfolioHolding>()
                .HasKey(ph => ph.HoldingId);

            modelBuilder.Entity<Alert>()
                .HasKey(a => a.AlertId);

            // Configure relationships

            // User -> Portfolios (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Portfolios)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Alerts (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Alerts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Portfolio -> PortfolioHoldings (One-to-Many)
            modelBuilder.Entity<Portfolio>()
                .HasMany(p => p.Holdings)
                .WithOne(ph => ph.Portfolio)
                .HasForeignKey(ph => ph.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);

            // PortfolioHolding -> Cryptocurrency (Many-to-One)
            modelBuilder.Entity<PortfolioHolding>()
                .HasOne(ph => ph.Cryptocurrency)
                .WithMany()
                .HasForeignKey(ph => ph.CryptoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Alert -> Cryptocurrency (Many-to-One)
            modelBuilder.Entity<Alert>()
                .HasOne(a => a.Cryptocurrency)
                .WithMany()
                .HasForeignKey(a => a.CryptoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Optional: Configure properties (e.g., required fields, max lengths)
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Cryptocurrency>()
                .Property(c => c.Symbol)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Cryptocurrency>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Portfolio>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            base.OnModelCreating(modelBuilder);
        }
    }
}
