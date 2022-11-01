using Application.UserTypes.Contracts;
using Domain.Alert.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        private readonly TraveloDbContext DbContext;

        public AlertRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<Alert>> GetAllAlerts()
        {
            return await DbContext.Alert.ToListAsync();
        }

        public async Task<List<Alert>> GetAlertsByContryId(int CountryId)
        {
            return await DbContext.Alert.Where(e => e.CountryId == CountryId).ToListAsync();
        }

    }
}
