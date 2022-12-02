using Application.TravelTypes.Contracts;
using Domain.Travels.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var results = await DbContext.Travel.Where(e => e.StartDate >= DateTime.Now).OrderBy(e => e.StartDate).ToListAsync();
            return results.First();
        }

        public async Task<int> AddNewTravel(Travel Travel)
        {
             await DbContext.Travel.AddAsync(Travel);
             await DbContext.SaveChangesAsync();
             return Travel.TravelId;
        }

        public async Task<Travel> GetTravelInfo(int TravelId)
        {
            return await DbContext.Travel.FirstAsync(e => e.TravelId == TravelId);
        }
    }
}
