using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Common.Repositories.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataModel
{
    public class TrefBlockDbContext : IdentityDbContext
    {
        public TrefBlockDbContext(DbContextOptions<TrefBlockDbContext> options)
        : base(options)
        {

        }

        public virtual DbSet<Realestate> Realestate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Keys of Identity tables are mapped in OnModelCreating method of IdentityDbContext
             * and if this method is not called, you will end up getting - > 
             * The entity type 'IdentityUserLogin' requires a primary key to be defined.*/
            base.OnModelCreating(modelBuilder);

            // Default Schema
            modelBuilder.HasDefaultSchema("dbo");

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                if (entityEntry.Entity is IGenericEntity entity)
                {
                    if (entityEntry.State == EntityState.Added)
                    {
                        entity.RowVersion = 1;
                    }
                    else if (entityEntry.State == EntityState.Modified)
                    {
                        entity.RowVersion += 1;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
