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
        Task<Alerts> GetAlertById(int id);
        Task<List<Alerts>> GetAlertsPackage(List<int> alertsIds);
    }
}
