using MicroservicesArtuchecture.AuthApi.Storage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesArtuchecture.AuthApi.Storage.Context
{
    public class DatabaseContext:IdentityDbContext<UserEntity>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base(options)
        {
            
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
