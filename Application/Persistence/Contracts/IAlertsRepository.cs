using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface IAlertsRepository : IGenericRepository<Alert>
    {
        Task<List<Alert>> GetAllAlerts();
        Task<List<Alert>> GetAlertsByCountry(int countryId);
    }
}
