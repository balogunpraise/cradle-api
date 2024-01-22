using Cradle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cradle.Persistence
{
    public class TenantContext : DbContext
    {
        private readonly IConfiguration _config;
        public TenantContext(DbContextOptions<TenantContext> option, IConfiguration config) 
            : base(option)
        {
            _config = config;
        }

        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<Tenant>())
            {
                entry.Entity.ConnectionString = string.IsNullOrWhiteSpace(entry.Entity.ConnectionString)
                    ? _config.GetConnectionString("cradledatabase") : entry.Entity.ConnectionString;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
