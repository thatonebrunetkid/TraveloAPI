using Application.DTOs.Travel;
using Application.Exceptions;
using Application.Features.UserTypes.Requests.Travel.Queries;
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
    public class GetTravelsListRequestHandler : IRequestHandler<GetTravelListRequest, List<AllTravelsDTO>>
    {
        private readonly ITravelsRepository _TravelsRepository;
        private readonly IMapper _Mapper;

        public GetTravelsListRequestHandler(ITravelsRepository travelsRepository, IMapper mapper)
        {
            _TravelsRepository = travelsRepository;
            _Mapper = mapper;
        }

        public async Task<List<AllTravelsDTO>> Handle(GetTravelListRequest request, CancellationToken cancellationToken)
        {
            var travels = await _TravelsRepository.GetAllTravelsAsync(request.UserId);

            if (travels == null)
                throw new NotFoundException(nameof(travels), request.UserId);

            return _Mapper.Map<List<AllTravelsDTO>>(travels);
        }
    }
}
