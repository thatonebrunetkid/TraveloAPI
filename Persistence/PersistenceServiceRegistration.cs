using Application.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TraveloDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AzureConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITravelsRepository, TravelRepository>();
            services.AddScoped<IAlertsRepository, AlertsRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<ISpotRepository, SpotRepository>();
            services.AddScoped<IOweSinglePaymentRepository, OweSinglePaymentRepository>();
            services.AddScoped<IVisitDateRepository, VisitDateRepository>();
            services.AddScoped<ISystemNotificationsRepository, SystemNotificationsRepository>();

            return services;
        }
    }
}
