using DiscountСardApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiscountСardApp.Infrastructure.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CommertialNetwork> CommertialNetworks { get; set; }
        public DbSet<DiscountCard> DiscountCards { get; set; }
        public DbSet<MCCCode> MCCCodes { get; set; }
        public DbSet<Store> Stores { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MCCCode>()
                .HasIndex(c => c.Code)
                .IsUnique();
        }
    }
}
