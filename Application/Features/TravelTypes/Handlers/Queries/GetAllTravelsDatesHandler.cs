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
    public class GetAllTravelsDatesHandler : IRequestHandler<GetTravelDatesFromCurrentMonthRequest, List<GetTravelDatesFromCurrentMonthDto>>
    {
        private readonly ITravelsRepository _TravelsRepository;
        private readonly IMapper _Mapper;

        public GetAllTravelsDatesHandler(ITravelsRepository TravelsRepository, IMapper Mapper)
        {
            _TravelsRepository = TravelsRepository;
            _Mapper = Mapper;
        }

        public async Task<List<GetTravelDatesFromCurrentMonthDto>> Handle(GetTravelDatesFromCurrentMonthRequest request, CancellationToken cancellationToken)
        {
            var Dates = await _TravelsRepository.GetAllTravelsAsync(request.UserId);
            return _Mapper.Map<List<GetTravelDatesFromCurrentMonthDto>>(Dates);
        }
    }
}
