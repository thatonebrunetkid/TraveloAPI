using Application.Features.CountriesTypes.Requests.Queries;
using Application.Persistence.Contracts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CountriesTypes.Handlers.Queries
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesRequest, List<Countries>>
    {
        private readonly ICountriesRepository _CountriesRepository;

        public GetAllCountriesHandler(ICountriesRepository countriesRepository)
        {
            _CountriesRepository = countriesRepository;
        }


        public async Task<List<Countries>> Handle(GetAllCountriesRequest request, CancellationToken cancellationToken)
        {
            var countries = await _CountriesRepository.GetAll();
            return countries;
        }
    }
}
