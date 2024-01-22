using Cradle.Application.Contracts.Infrastructure;
using Cradle.Application.Models.Mail;
using Cradle.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Infrastructure
{
    public static class InfrastructureServices
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services,
            IConfiguration config)
        {
            //services.Configure<EmailSettings>(config.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            //return services;
        }
    }
}
