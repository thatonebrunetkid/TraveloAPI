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
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly TraveloDbContext _dbContext;

        public CountriesRepository(TraveloDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Country> GetCountryIdByName(string name)
        {
            return await _dbContext.Country.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<List<Country>> GetCountriesNamesList(string phrase)
        {
            return await _dbContext.Country.FromSqlRaw($"exec dbo.FindCountry '{phrase}'").ToListAsync();
        }

        public async Task<Country> GetCountryInfo(int countryId)
        {
            return await _dbContext.Country.FirstAsync(e => e.CountryId == countryId);
        }
    }
}
