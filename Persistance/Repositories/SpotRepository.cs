using Application.SpotTypes.Contracts;
using Domain.Spot.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class SpotRepository : ISpotRepository
    {
        private readonly TraveloDbContext DbContext;

        public SpotRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<Spot>> GetSpotInfoByVisitDate(int VisitDateId)
        {
            return await DbContext.Spot.Where(e => e.VisitDateId == VisitDateId).ToListAsync();
        }

        public async Task<int> AddNewSpot(Spot Spot)
        {
            await DbContext.Spot.AddAsync(Spot);
            await DbContext.SaveChangesAsync();
            return Spot.SpotId;
        }

        public async Task<bool> DeleteSpot(int VisitDateId)
        {
            try
            {
                DbContext.Spot.RemoveRange(await GetSpotInfoByVisitDate(VisitDateId));
                await DbContext.SaveChangesAsync();
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public async Task<int> UpdateSpot(Spot Spot)
        {
            DbContext.Spot.Update(Spot);
            DbContext.Entry(Spot).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return Spot.SpotId;
        }
    }
}
