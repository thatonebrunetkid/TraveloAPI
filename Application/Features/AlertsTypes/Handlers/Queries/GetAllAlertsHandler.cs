using Application.DTOs.Alerts;
using Application.Exceptions;
using Application.Features.AlertsTypes.Requests.Queries;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AlertsTypes.Handlers.Queries
{
    public class GetAllAlertsHandler : IRequestHandler<GetAllAlertsRequest, List<AlertDto>>
    {
        private readonly IAlertsRepository _AlertsRepository;
        private readonly IMapper _Mapper;

        public GetAllAlertsHandler(IAlertsRepository AlertsRepository, IMapper Mapper)
        {
            _AlertsRepository = AlertsRepository;
            _Mapper = Mapper;
        }

        public async Task<List<AlertDto>> Handle(GetAllAlertsRequest request, CancellationToken cancellationToken)
        {
            var alerts = await _AlertsRepository.GetAllAlerts();
            return _Mapper.Map<List<AlertDto>>(alerts);
        }
    }
}
