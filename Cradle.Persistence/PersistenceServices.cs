using Cradle.Application.Contracts.Persistence;
using Cradle.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cradle.Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
            var connectionString = isDevelopment ? config.GetConnectionString("DefaultConnection") 
                : Environment.GetEnvironmentVariable("CONNECTION_STRING");
            services.AddDbContext<CradleContext>(options => options.UseNpgsql(connectionString), ServiceLifetime.Scoped);
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddDbContext<TenantContext>(options => options.UseNpgsql(config.GetConnectionString("TenantConnection")));
            return services;
        }
    }
}
