﻿using Azure.Core;
using Cradle.Application.Common.Authorization;
using Cradle.Application.Contracts.Persistence;
using Cradle.Application.Features.TenantFeature.Command.RegisterTenant;
using Cradle.Domain.Entities;
using Cradle.Domain.Entities.Account;
using Cradle.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cradle.Persistence
{
    public class AppIdentitySeeder
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly CradleContext _context;
        private readonly ITenantRepository _tenantRepository;
        private readonly ISchoolRepository _schoolRepository;

        public AppIdentitySeeder(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            CradleContext context, ITenantRepository tenantRepository
            , ISchoolRepository schoolRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _tenantRepository = tenantRepository;
            _schoolRepository = schoolRepository;
        }

        public async Task SeedDatabaseAsync()
        {
            //Seed data base
            await CheckPendingMigrations();
            await SeedRolesAsync();
            await SeedUserAsync();
        }

        private async Task CheckPendingMigrations()
        {
            if (_context.Database.GetPendingMigrations().Any())
            {
                await _context.Database.MigrateAsync();
            }
        }

        private async Task SeedUserAsync()
        {
            var tenant = await CreateDefaultTenant();
            var school = await CreateNewSchool(tenant, tenant.Id);

            var exits = await _userManager.FindByEmailAsync(AppCredentials.AdminEmail);
            if (exits == null)
            {
                var user = new ApplicationUser
                {
                    Email = AppCredentials.AdminEmail,
                    UserName = AppCredentials.AdminEmail.Split("@")[0],
                    FirstName = "Test Firstname",
                    LastName = "Test Lastname",
                    TenantId = tenant.Id,
                    SchoolId = school
                };
                await _userManager.CreateAsync(user, AppCredentials.AdminPassword);
                if (!await _userManager.IsInRoleAsync(user, AppRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user, AppRoles.Admin);
                }

            }

            var basicuserExists = await _userManager.FindByEmailAsync(AppCredentials.BasicEmail);
            if (basicuserExists == null)
            {
                var basicUser = new ApplicationUser
                {
                    Email = AppCredentials.BasicEmail,
                    UserName = AppCredentials.BasicEmail.Split("@")[0],
                    FirstName = "Basic First",
                    LastName = "Basic Last",
                    TenantId = tenant.Id,
                    SchoolId = school
                };

                await _userManager.CreateAsync(basicUser, AppCredentials.BasicPassword);
                if (!await _userManager.IsInRoleAsync(basicUser, AppRoles.Basic))
                {
                    await _userManager.AddToRoleAsync(basicUser, AppRoles.Basic);
                }
            }

        }
        private async Task SeedRolesAsync()
        {
            foreach (var roleName in AppRoles.DefaultRoles)
            {
                if (await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == roleName)
                    is not ApplicationRole role)
                {
                    role = new ApplicationRole
                    {
                        Name = roleName,
                        Description = $"{roleName} role"
                    };
                    await _roleManager.CreateAsync(role);

                    if (roleName == AppRoles.Admin)
                    {
                        await AssignPermissionsToRoleAsync(role, AppPermissions.AdminPermission);
                    }
                    else if (roleName == AppRoles.Basic)
                    {
                        await AssignPermissionsToRoleAsync(role, AppPermissions.BasicPermissions);
                    }
                }
            }
        }

        private async Task AssignPermissionsToRoleAsync(ApplicationRole role, IReadOnlyList<AppPermission> permissions)
        {
            var currentClaim = await _roleManager.GetClaimsAsync(role);
            foreach (var permission in permissions)
            {
                if (!currentClaim.Any(claim => claim.Type == AppClaim.Permission && claim.Value == permission.Name))
                {
                    await _context.RoleClaims.AddAsync(new ApplicationRoleClaim
                    {
                        RoleId = role.Id,
                        ClaimType = AppClaim.Permission,
                        ClaimValue = permission.Name,
                        Description = permission.Description,
                        Group = permission.Group,
                    });
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task<Tenant> CreateDefaultTenant()
        {
            var secret = Guid.NewGuid().ToString();
            var tenant = new Tenant
            {
                Name = "crest",
                Secret = secret,
                ConnectionString = string.Empty
            };
            await _tenantRepository.RegisterTenant(tenant);
            return tenant;
        }

        private async Task<string> CreateNewSchool(Tenant tenant, string tenantId)
        {
            var school = new School
            {
                Name = tenant.Name,
                ShortCode = "TET",
                TenantId = tenantId
            };
            await _schoolRepository.CreateSchool(school);
            return school.Id;
        }

    }
}
