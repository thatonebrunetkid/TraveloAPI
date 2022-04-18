using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            //to zapewnia pokrycie kazdego profilu mappera poprzez refleksje
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //to samo ale dla mediatora. Wyszukuje requests/response objects poprzez refleksjse
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
