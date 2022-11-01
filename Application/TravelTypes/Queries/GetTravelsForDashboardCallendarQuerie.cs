using Application.TravelTypes.Contracts;
using AutoMapper;
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
    public class GetTravelsForDashboardCalendarQuerieRequest : IRequest<List<TravelDashboardCalendarDTO>>
    {
        public int UserId;
    }

    public class GetTravelsForDashboardCalendarQuerieHandler : IRequestHandler<GetTravelsForDashboardCalendarQuerieRequest, List<TravelDashboardCalendarDTO>>
    {
        private readonly ITravelRepository Repository;
        private readonly IMapper Mapper;

        public GetTravelsForDashboardCalendarQuerieHandler(ITravelRepository Repository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
        }

        public async Task<List<TravelDashboardCalendarDTO>> Handle(GetTravelsForDashboardCalendarQuerieRequest request, CancellationToken cancellationToken)
        {
            var results = await Repository.GetTravelsForDashboardCalendar(request.UserId);
            return Mapper.Map<List<TravelDashboardCalendarDTO>>(results);
        }
    }
}
