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
    }
}
