using Application.DTOs.Countries;
using Application.Persistence.Contracts;
using Domain.Entities;
using Microsoft.Data.SqlClient;
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

        public async Task<Countries> GetCountryIdByName(string name)
        {
            return await _dbContext.Countries.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<List<Countries>> GetCountriesNamesList(string phrase)
        {
            return await _dbContext.Countries.FromSqlRaw($"exec dbo.FindCountry '{phrase}'").ToListAsync();
        }

        public async Task<Countries> GetCountryInfo(int countryId)
        {
            return await _dbContext.Countries.FirstAsync(e => e.CountryId == countryId);
        }
    }
}
