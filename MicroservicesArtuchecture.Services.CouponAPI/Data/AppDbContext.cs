using MicroservicesArtuchecture.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MicroservicesArtuchecture.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Coupon> Coupons { get; set; }
        

    }
}
