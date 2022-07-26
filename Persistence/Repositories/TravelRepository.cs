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
    public class TravelRepository : GenericRepository<Travel>, ITravelsRepository
    {
        private readonly TraveloDbContext _dbContext;

        public TravelRepository (TraveloDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Travel>> GetAllTravelsAsync(int UserId)
        {
            return await _dbContext.Travel.Where(x => x.UserId == UserId).ToListAsync();
        }

        public async Task<Travel> GetCurrentTravel(int UserId)
        {
            var Travel = await _dbContext.Travel.FirstOrDefaultAsync(e => e.StartDate.Date <= DateTime.Now.Date && e.EndDate.Date >= DateTime.Now.Date && e.UserId == UserId);
            if (Travel is null)
                Travel = await _dbContext.Travel.FirstOrDefaultAsync(e => e.StartDate.Date > DateTime.Now.Date && e.UserId == UserId);
            return Travel;
        }

        public async Task<List<Travel>> GetTravelsForCurrentMonth(int userId)
        {
            var Dates = await _dbContext.Travel.Where(e => e.StartDate.Month == DateTime.Now.Month && e.UserId == userId).ToListAsync();
            var temp = 1;
            return Dates;
        }
    }
}
