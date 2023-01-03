using Application.ServicePhoneTypes.Contracts;
using Domain.Country.Entities;
using Domain.ServicePhone.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class PhoneServiceRepository : IServicePhoneRepository
    {
        private readonly TraveloDbContext DbContext;

        public PhoneServiceRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<ServicePhone> GetServicePhone(int Id)
        {
            return await DbContext.ServicePhone.FirstAsync(e => e.ServicePhoneId == Id);
        }

        public async Task<List<ServicePhone>> GetAll()
        {
            return await DbContext.ServicePhone.ToListAsync();
        }
    }
}
