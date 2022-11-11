using Application.ContryTypes.Contracts;
using Domain.Country.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly TraveloDbContext DbContext;

        public CountryRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<Country>> GetCountryNames(string Phrase)
        {
            return await DbContext.Country.FromSqlRaw($"exec dbo.FindCountry '{Phrase}'").ToListAsync();
        }

        public async Task<Country> GetCountryInfo(int CountryId)
        {
            return await DbContext.Country.FirstAsync(e => e.CountryId == CountryId);
        }

        public async Task<List<Country>> GetAllCountries()
        {
            return await DbContext.Country.ToListAsync();
        }
    }
}
