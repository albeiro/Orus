using Microsoft.EntityFrameworkCore;
using prYuset.Models;

namespace prYuset.YSDBContext
{
    public class YuseftDbContext : DbContext
    {
        public YuseftDbContext(DbContextOptions options) : base(options)
        {
        }

        protected YuseftDbContext()
        {
        }

        public DbSet<prYuset.Models.Empleado>? Empleado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleado");
            });
        }

        public DbSet<prYuset.Models.Cargo>? Cargo { get; set; }
    }
}
