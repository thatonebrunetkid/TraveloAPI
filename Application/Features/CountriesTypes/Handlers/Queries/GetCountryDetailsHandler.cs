using Application.DTOs.Countries;
using Application.Exceptions;
using Application.Features.CountriesTypes.Requests.Queries;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CountriesTypes.Handlers.Queries
{
    public class GetCountryDetailsHandler : IRequestHandler<GetCountryDetailsRequest, CountriesDto>
    {
        private readonly ICountriesRepository _CountriesRepository;
        private readonly IMapper _Mapper;

        public GetCountryDetailsHandler(ICountriesRepository countriesRepository, IMapper mapper)
        {
            _CountriesRepository = countriesRepository;
            _Mapper = mapper;
        }


         public async Task<CountriesDto> Handle(GetCountryDetailsRequest request, CancellationToken cancellationToken)
        {
            var Country = await _CountriesRepository.GetCountryDetails(request.CountryId);
            if (Country == null)
                throw new NotFoundException(nameof(Country), request.CountryId);

            return _Mapper.Map<CountriesDto>(Country);
        }
    }
}
