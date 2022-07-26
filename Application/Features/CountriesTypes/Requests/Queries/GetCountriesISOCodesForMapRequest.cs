using Application.DTOs.Countries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CountriesTypes.Requests.Queries
{
    public class GetCountriesISOCodesForMapRequest : IRequest<List<CountriesISOCodesDto>>
    {
        public int UserId { get; set; }
    }
}
