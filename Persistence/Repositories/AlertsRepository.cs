using Application.Persistence.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AlertsRepository : GenericRepository<Alerts>, IAlertsRepository
    {
        private readonly TraveloDbContext _dbContext;

        public AlertsRepository(TraveloDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Alerts>> GetAlertsByCountry(int countryId)
        {
            return await _dbContext.Alerts.Where(e => e.CountryId == countryId).ToListAsync();
        }

        public async Task<List<Alerts>> GetAllAlerts()
        {
            return await _dbContext.Alerts.ToListAsync();
        }
    }
}
