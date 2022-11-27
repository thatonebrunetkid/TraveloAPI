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
            await DbContext.Database.ExecuteSqlRawAsync($"exec dbo.AddSpot '{Spot.Note}', '{Spot.Order}', '{Spot.Street}', '{Spot.BuildingNo}', '{Spot.FlatNo}', '{Spot.ZipCode}', '{Spot.VisitDateId}', '{Spot.ExpenseId}'");
            await DbContext.SaveChangesAsync();
            return Spot.SpotId;
        }
    }
}
