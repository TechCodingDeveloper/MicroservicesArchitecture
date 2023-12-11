using MicroservicesArtuchecture.Services.CouponAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MicroservicesArtuchecture.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<CouponEntity> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CouponEntity>().HasData(new CouponEntity
            {
                CouponId = 1,
                CouponCode ="100OFF",
                DiscountAmount = 10,
                MinAmount = 10,
            });
            modelBuilder.Entity<CouponEntity>().HasData(new CouponEntity
            {
                CouponId = 2,
                CouponCode = "50OFF",
                DiscountAmount = 20,
                MinAmount = 40,
            });
        }

    }
}
