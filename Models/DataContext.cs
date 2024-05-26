using BigonApp.Models.Entities;
using BigonApp.Models.Persistences.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BigonApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
