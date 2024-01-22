using Cradle.Domain.Entities;
using Cradle.Domain.Entities.Account;
using Cradle.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cradle.Persistence
{
    public class CradleContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
        IdentityUserRole<string>, IdentityUserLogin<string>, ApplicationRoleClaim, IdentityUserToken<string>>
    {
        public CradleContext(DbContextOptions option) : base(option)
        {
            
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(CradleContext).Assembly);
        }

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
