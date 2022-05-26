using Application.DTOs.Countries;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Countries>
    {
        Task<Countries> GetCountryIdByName(string name);
        Task<List<Countries>> GetCountriesNamesList(string phrase);
        Task<Countries> GetCountryInfo(int countryId);
    }
}
