using Application.Common;
using Application.Models;
using Infrastructure.Cache;
using Infrastructure.Email;
using Infrastructure.SCA;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IRedisHandler, Redis>();
            services.AddSingleton<IAuthorisationHelpers, AuthorizationHelpers>();
            return services;
        }
    }
}
