using Cradle.Application.Contracts.Persistence;
using Cradle.Domain.Entities;

namespace Cradle.Persistence.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly TenantContext _tenantContext;
        public TenantRepository(TenantContext tenantContext)
        {

            _tenantContext = tenantContext;

        }
        public async Task RegisterTenant(Tenant tenant)
        {
            await _tenantContext.Tenants.AddAsync(tenant);
            await _tenantContext.SaveChangesAsync();
        }
    }
}
