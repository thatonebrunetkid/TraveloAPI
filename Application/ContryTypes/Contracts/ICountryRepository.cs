using Domain.Country.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ContryTypes.Contracts
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountryNames(string Phrase);
        Task<Country> GetCountryInfo(int CountryId);
    }
}
