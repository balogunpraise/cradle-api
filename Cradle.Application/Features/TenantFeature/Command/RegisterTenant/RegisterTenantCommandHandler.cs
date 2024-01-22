using Cradle.Application.Contracts.Persistence;
using Cradle.Domain.Entities;
using MediatR;

namespace Cradle.Application.Features.TenantFeature.Command.RegisterTenant
{
    public class RegisterTenantCommandHandler : IRequestHandler<RegisterTenantCommand>
    {
        private readonly ITenantRepository _tenantRepository;
        public RegisterTenantCommandHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public async Task Handle(RegisterTenantCommand request, CancellationToken cancellationToken)
        {
            var secret = Guid.NewGuid().ToString();
            var tenant = new Tenant
            {
                Name = request.Name,
                Secret = secret,
                ConnectionString = request.DedicatedDb ?
                    @$"User ID=postgres;Password={secret};Host=localhost;Port=5432;Database={request.Name}-db;Include Error Detail=true;"
                    : string.Empty
            };
            await _tenantRepository.RegisterTenant(tenant);
        }
    }
}
