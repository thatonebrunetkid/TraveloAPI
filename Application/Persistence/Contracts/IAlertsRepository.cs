using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface IAlertsRepository : IGenericRepository<Alerts>
    {
        Task<List<Alerts>> GetAllAlerts();
        Task<List<Alerts>> GetAlertsByCountry(int countryId);
    }
}
