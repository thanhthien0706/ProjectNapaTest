using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Napa.Models;

namespace Napa.DataAccess.Data
{
    //IdentityDbContext<IdentityUser>
    public class DbContextApplication : IdentityDbContext<IdentityUser>
    {
        public DbContextApplication(DbContextOptions<DbContextApplication> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<TestEntity> TestEntities { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries()
                                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreateAt = DateTime.UtcNow;
                }

                ((BaseEntity)entity.Entity).UpdateAt = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
