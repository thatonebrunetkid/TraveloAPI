using Application.UserTypes.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Repositories;
using Application.ContryTypes.Contracts;
using Application.TravelTypes.Contracts;
using Application.DictionaryTypes.Contracts;
using Application.SystemNotificationsType.Contracts;
using Application.Flag.Contracts;
using Application.ServicePhoneTypes.Contracts;

namespace Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TraveloDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AzureConnectionString")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAlertRepository, AlertRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ITravelRepository, TravelRepository>();
            services.AddScoped<IDictionaryRepository, DictionaryRepository>();
            services.AddScoped<ISystemNotificationRepository, SystemNotificationRepository>();
            services.AddScoped<IFlagRepository, FlagRepository>();
            services.AddScoped<IServicePhoneRepository, PhoneServiceRepository>();

            return services;
        }
    }
}
