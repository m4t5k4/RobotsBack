using RobotsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RobotsAPI.Data
{
    public class RobotsContext : DbContext
    {
        public RobotsContext(DbContextOptions<RobotsContext> options) : base(options)
        {
        }

        public DbSet<Robot> Robots { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Robot>().ToTable("Robot");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
