using Application.VisitDateTypes.Contracts;
using Domain.VisitDate.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class VisitDateRepository : IVisitDatesRepository
    {
        private readonly TraveloDbContext DbContext;

        public VisitDateRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<VisitDate>> GetVisitDateInfoByTravel(int TravelId)
        {
            return await DbContext.VisitDate.Where(e => e.TravelId == TravelId).ToListAsync();
        }

        public async Task<int> AddNewVisitDate(VisitDate VisitDate)
        {
            await DbContext.VisitDate.AddAsync(VisitDate);
            await DbContext.SaveChangesAsync();
            return VisitDate.VisitDateId;
        }

        public async Task<bool> DeleteVisitDates(int VisitDateId)
        {
            try
            {
               DbContext.VisitDate.RemoveRange(DbContext.VisitDate.Where(e => e.VisitDateId == VisitDateId));
                await DbContext.SaveChangesAsync();
                return true;
            } catch(Exception)
            {
                return false;
            }
        }

        public async Task<int> UpdateVisitDate(VisitDate visitDate)
        {
            DbContext.VisitDate.Update(visitDate);
            DbContext.Entry(visitDate).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return visitDate.VisitDateId;
        }
    }
}
