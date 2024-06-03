using BigonApp.Helpers.Services;
using BigonApp.Models.Entities;
using BigonApp.Models.Entities.Common;
using BigonApp.Models.Persistences.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BigonApp.Models
{
    public class DataContext : DbContext
    {
        private readonly IDatetimeService _ds;
        private readonly IUserService _us;

        public DataContext(DbContextOptions options,IDatetimeService ds,IUserService us) : base(options)
        {
            _ds=ds;
            _us=us;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public override int SaveChanges()
        {

            var changes = this.ChangeTracker.Entries<IAuditableEntity>();
            if (changes != null)
            {
                foreach (var entry in changes.Where(c => c.State == EntityState.Added || c.State == EntityState.Modified || c.State == EntityState.Deleted))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedAt=_ds.ExecutingTime;
                            entry.Entity.CreatedBy=_us.GetUserId();
                            break;
                        case EntityState.Modified:
                            entry.Entity.ModifiedAt=_ds.ExecutingTime;
                            entry.Entity.ModifiedBy=_us.GetUserId();
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.Entity.DeletedAt=_ds.ExecutingTime;
                            entry.Entity.DeletedBy=_us.GetUserId();
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
