using Application.TravelTypes.Contracts;
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
    public class GetAllTravelsQuerieRequest : IRequest<List<TravelDTO>>
    {
        public int UserId { get; set; }
    }

    public class GetAllTravelsQuerieHandler : IRequestHandler<GetAllTravelsQuerieRequest, List<TravelDTO>>
    {
        private readonly ITravelRepository Repository;
        private readonly IMapper Mapper;

        public GetAllTravelsQuerieHandler(ITravelRepository Repository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
        }

        public async Task<List<TravelDTO>> Handle(GetAllTravelsQuerieRequest request, CancellationToken cancellationToken)
        {
            var travels = await Repository.GetAllTravels(request.UserId);
            return Mapper.Map<List<TravelDTO>>(travels);
        }
    }
}
