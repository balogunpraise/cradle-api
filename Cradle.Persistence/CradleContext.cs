using Cradle.Domain.Entities;
using Cradle.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Cradle.Persistence
{
    public class CradleContext(DbContextOptions<CradleContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken
            = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<FullAuditedEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTimeOffset.Now;
                        break;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
  
}
