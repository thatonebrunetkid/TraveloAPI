using Application.DTOs.Countries;
using Application.Features.CountriesTypes.Requests.Queries;
using Application.Persistence.Contracts;
using AutoMapper;
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
    public class GetCountriesISOCodesForMapHandler : IRequestHandler<GetCountriesISOCodesForMapRequest, List<CountriesISOCodesDto>>
    {
        private readonly ICountriesRepository _CountriesRepository;
        private readonly ITravelsRepository _TravelsRepository;
        private readonly IMapper _Mapper;

        public GetCountriesISOCodesForMapHandler(ICountriesRepository CountriesRepository, ITravelsRepository TravelsRepository, IMapper Mapper)
        {
            _CountriesRepository = CountriesRepository;
            _TravelsRepository = TravelsRepository;
            _Mapper = Mapper;
        }

        public async Task<List<CountriesISOCodesDto>> Handle(GetCountriesISOCodesForMapRequest request, CancellationToken cancellationToken)
        {
            var Travels = _TravelsRepository.GetAllTravelsAsync(request.UserId).Result.Where(e => e.EndDate < DateTime.Now);
            List<Country> Countries = new List<Country>();

            foreach(Travel travel in Travels)
            {
                Countries.Add(_CountriesRepository.GetCountryInfo(travel.CountryId).Result);
            }

            return _Mapper.Map<List<CountriesISOCodesDto>>(Countries);
        }
    }
}
