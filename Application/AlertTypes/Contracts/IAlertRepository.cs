using Domain.Alert.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTypes.Contracts
{
    public interface IAlertRepository
    {
        Task<List<Alert>> GetAllAlerts();
        Task<List<Alert>> GetAlertsByContryId(int CountryId);
    }
}
