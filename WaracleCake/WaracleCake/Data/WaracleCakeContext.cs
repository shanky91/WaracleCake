using Microsoft.EntityFrameworkCore;
using WaracleCake.Configuration;
using WaracleCake.Models;

namespace WaracleCake.Data
{
    public class WaracleCakeContext : DbContext
    {
        public WaracleCakeContext (DbContextOptions<WaracleCakeContext> options)
            : base(options)
        {
        }

        public DbSet<Cake> Cake { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CakeConfiguration());
        }
    }
}
