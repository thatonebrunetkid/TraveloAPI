using Application.DTOs.Countries;
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
    public class CountriesRepository : GenericRepository<Countries>, ICountriesRepository
    {
        private readonly TraveloDbContext _dbContext;

        public CountriesRepository(TraveloDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Countries> GetCountryDetails(int id)
        {
            var countries = await _dbContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);
            return countries;
        }

         async Task<List<Countries>> ICountriesRepository.GetAll()
        {
            return await _dbContext.Countries.ToListAsync();
        }
    }
}
