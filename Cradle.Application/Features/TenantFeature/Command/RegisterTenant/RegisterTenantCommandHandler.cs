using Cradle.Application.Contracts.Persistence;
using Cradle.Domain.Entities;
using Cradle.Domain.Entities.Account;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cradle.Application.Features.TenantFeature.Command.RegisterTenant
{
    public class RegisterTenantCommandHandler : IRequestHandler<RegisterTenantCommand>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public RegisterTenantCommandHandler(ITenantRepository tenantRepository, 
            ISchoolRepository schoolRepository,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _tenantRepository = tenantRepository;
            _schoolRepository = schoolRepository;

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
            await CreateNewSchool(request, tenant.Id);
            
        }


        private async Task<int> CreateNewSchool(RegisterTenantCommand tenant, string tenantId)
        {
            var school = new School
            {
                Name = tenant.Name,
                ShortCode = tenant.ShortCode,
                TenantId = tenantId
            };
            return await _schoolRepository.CreateSchool(school);
        }

        private async Task CreateAdminAccount(RegisterTenantCommand tenant, string tenantId)
        {
            var existingUser = await _userManager.FindByEmailAsync(tenant.Email);
            if (existingUser != null)
                throw new Exception("User already exists");
            var user = new ApplicationUser
            {
                FirstName = $"{tenant.Name} Admin",
                LastName = tenant.Name,
                Email = tenant.Email,
            };
            await _userManager.CreateAsync(user, tenant.Password);
            await _userManager.AddToRoleAsync(user, "Admin");
            return ;
        }
    }
}
