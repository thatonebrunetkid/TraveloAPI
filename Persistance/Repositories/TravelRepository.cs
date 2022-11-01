using Application.TravelTypes.Contracts;
using Domain.Travels.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly TraveloDbContext DbContext;

        public TravelRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<Travel>> GetAllTravels(int userId)
        {
            return await DbContext.Travel.Where(e => e.UserId == userId).ToListAsync();
        }

        public async Task<List<Travel>> GetTravelsForDashboardCalendar(int userId)
        {
            return await DbContext.Travel.Where(e => e.UserId == userId && e.StartDate.Month == DateTime.Now.Month).ToListAsync();
        }

        public async Task<Travel> GetUpcomingTravel(int UserId)
        {
            var result = await DbContext.Travel.FirstOrDefaultAsync(e => e.StartDate >= DateTime.Now && e.EndDate <= DateTime.Now && e.UserId == UserId);
            if (result is null)
                result = await DbContext.Travel.FirstOrDefaultAsync(e => e.StartDate >= DateTime.Now && e.UserId == UserId);
            return result;
        }
    }
}
