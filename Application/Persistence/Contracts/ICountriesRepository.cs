using Application.DTOs.Countries;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetCountryIdByName(string name);
        Task<List<Country>> GetCountriesNamesList(string phrase);
        Task<Country> GetCountryInfo(int countryId);
    }
}
