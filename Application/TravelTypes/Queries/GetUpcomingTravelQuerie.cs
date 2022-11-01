using Application.ContryTypes.Contracts;
using Application.Flag.Contracts;
using Application.TravelTypes.Contracts;
using Application.UserTypes.Contracts;
using AutoMapper;
using Domain.Alert.DTO;
using Domain.Travels.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TravelTypes.Queries
{
    public class GetUpcomingTravelQuerieRequest : IRequest<GetUpcomingTravelDTO>
    {
        public int UserId;
    }

    public class GetUpcomingTravelQuerieHandler : IRequestHandler<GetUpcomingTravelQuerieRequest, GetUpcomingTravelDTO>
    {
        private readonly ITravelRepository TravelRepository;
        private readonly ICountryRepository CountryRepository;
        private readonly IAlertRepository AlertRepository;
        private readonly IFlagRepository FlagRepository;
        private readonly IMapper Mapper;

        public GetUpcomingTravelQuerieHandler(ITravelRepository TravelRepository, ICountryRepository CountryRepository, IAlertRepository AlertRepository, IFlagRepository FlagRepository ,IMapper Mapper)
        {
            this.TravelRepository = TravelRepository;
            this.CountryRepository = CountryRepository;
            this.AlertRepository = AlertRepository;
            this.FlagRepository = FlagRepository;
            this.Mapper = Mapper;
        }

        public async Task<GetUpcomingTravelDTO> Handle(GetUpcomingTravelQuerieRequest request, CancellationToken cancellationToken)
        {
            var Travel = await TravelRepository.GetUpcomingTravel(request.UserId);
            if (Travel is null) return null;
            var Country = await CountryRepository.GetCountryInfo(Travel.CountryId);
            var Alerts = await AlertRepository.GetAlertsByContryId(Travel.CountryId);

            return new GetUpcomingTravelDTO
            {
                CountryName = Country.Name,
                Currency = Country.Currency,
                PlannedBudget = Travel.PlannedBudget,
                FlagUrl = FlagRepository.GetFlag(Country.FlagId).Result,
                CountryAlerts = Mapper.Map<List<AllAlertsDTO>>(Alerts)
            };
        }
    }
}
