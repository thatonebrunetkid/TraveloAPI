using Application.DTOs.Travel;
using Application.Features.TravelTypes.Requests.Travel.Queries;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TravelTypes.Handlers.Queries
{
    public class GetCurrentTravelInformationHandler : IRequestHandler<GetCurrentTravelInformationRequest, GetCurrentTravelInformationDto>
    {
        private readonly ITravelsRepository _TravelsRepository;
        private readonly ICountriesRepository _CountriesRepository;
        private readonly IAlertsRepository _AlertsRepository;
        private readonly IMapper _Mapper;

        public GetCurrentTravelInformationHandler(ITravelsRepository TravelsReposiotry, ICountriesRepository CountriesRepository, IAlertsRepository AlertsReposiotry, IMapper mapper)
        {
            _TravelsRepository = TravelsReposiotry;
            _CountriesRepository = CountriesRepository;
            _AlertsRepository = AlertsReposiotry;
            _Mapper = mapper;
        }

        public async Task<GetCurrentTravelInformationDto> Handle(GetCurrentTravelInformationRequest request, CancellationToken cancellationToken)
        {
            var Travel = await _TravelsRepository.GetCurrentTravel(request.UserId);
            if (Travel is null) return null;
            var Country = await _CountriesRepository.GetCountryInfo(Travel.CountryId);
            var Alerts = await _AlertsRepository.GetAlertsByCountry(Travel.CountryId);

            return new GetCurrentTravelInformationDto()
            {
                CountryName = Country.Name,
                Currency = Country.Currency,
                PlannedBudged = Travel.PlannedBudget,
                FlagUrl = "https://www.someflagapi.com/someflag",
                CountryAlerts = Alerts
            };
        }
    }
}
