using Application.DTOs.Countries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CountriesTypes.Requests.Queries
{
    public class GetCountryByNameRequest : IRequest<GetCountryIdByNameDto>
    {
        public string CountryName { get; set; }
    }
}
