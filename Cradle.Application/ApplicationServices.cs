using Microsoft.Extensions.DependencyInjection;

namespace Cradle.Application
{
    public static class ApplicationServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(config => 
                config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            //return services;
        }
    }
}
