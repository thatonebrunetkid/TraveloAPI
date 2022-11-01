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
    public class GetAllTravelsForEntireCalendarQuerieRequest : IRequest<List<TravelDashboardCalendarDTO>>
    {
        public int UserId;
    }

    public class GetAllTravelsForEntireCalendarQuerieHandler : IRequestHandler<GetAllTravelsForEntireCalendarQuerieRequest, List<TravelDashboardCalendarDTO>>
    {
        private readonly ITravelRepository Repository;
        private readonly IMapper Mapper;

        public GetAllTravelsForEntireCalendarQuerieHandler(ITravelRepository Repository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
        }

        public async Task<List<TravelDashboardCalendarDTO>> Handle(GetAllTravelsForEntireCalendarQuerieRequest request, CancellationToken cancellationToken)
        {
            var result = await Repository.GetAllTravels(request.UserId);
            return Mapper.Map<List<TravelDashboardCalendarDTO>>(result);
        }
    }
}
