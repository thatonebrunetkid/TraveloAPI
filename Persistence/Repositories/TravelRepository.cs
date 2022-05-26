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
    public class TravelRepository : GenericRepository<Travels>, ITravelsRepository
    {
        private readonly TraveloDbContext _dbContext;

        public TravelRepository (TraveloDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Travels>> GetAllTravelsAsync(int UserId)
        {
            return await _dbContext.Travels.Where(x => x.UserId == UserId).ToListAsync();
        }

        public async Task<Travels> GetCurrentTravel(int UserId)
        {
            var Travel = await _dbContext.Travels.FirstOrDefaultAsync(e => e.StartDate.Date <= DateTime.Now.Date && e.EndDate.Date >= DateTime.Now.Date && e.UserId == UserId);
            if (Travel is null)
                Travel = await _dbContext.Travels.FirstOrDefaultAsync(e => e.StartDate.Date > DateTime.Now.Date && e.UserId == UserId);
            return Travel;
        }

        public async Task<List<Travels>> GetTravelsForCurrentMonth(int userId)
        {
            var Dates = await _dbContext.Travels.Where(e => e.StartDate.Month == DateTime.Now.Month && e.UserId == userId).ToListAsync();
            return Dates;
        }
    }
}
