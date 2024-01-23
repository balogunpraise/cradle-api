using Cradle.Api.Permissions;
using Cradle.Application.Contracts.Infrastructure;
using Cradle.Application.Profiles;
using Cradle.Domain.Entities.Account;
using Cradle.Infrastructure;
using Cradle.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Cradle.Api
{
    public static class SeviceExtensions
    {
        internal static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var seeders = serviceScope.ServiceProvider.GetServices<AppIdentitySeeder>();
            foreach (var seeder in seeders)
            {
                seeder.SeedDatabaseAsync().GetAwaiter().GetResult();
            }
            return app;
        }

        internal static IServiceCollection AddIdentitySettings(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            //services.AddAutoMapper(typeof(MappingProfiles));
            /*services.AddIdentity<ApplicationUser, ApplicationRole>(option =>
            {
                option.Password.RequiredLength = 6;
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();*/
            return services;
        }

        internal static void AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(configuration["Token:key"]);
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<CradleContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
