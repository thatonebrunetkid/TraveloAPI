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

        public Task<Travels> GetTravelByIdAsync(int TravelId)
        {
            throw new NotImplementedException();
        }
    }
}
