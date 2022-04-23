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
    public class GetAlertDetailsHandler : IRequestHandler<GetAlertDetailsRequest, AlertDto>
    {
        private readonly IAlertsRepository _AlertRepository;
        private readonly IMapper _Mapper;

        public GetAlertDetailsHandler(IAlertsRepository alertRepository, IMapper mapper)
        {
            _AlertRepository = alertRepository;
            _Mapper = mapper;
        }


         public async Task<AlertDto> Handle(GetAlertDetailsRequest request, CancellationToken cancellationToken)
        {
            var alert = await _AlertRepository.Get(request.AlertId);
            if (alert == null)
                throw new NotFoundException(nameof(alert), request.AlertId);
            return _Mapper.Map<AlertDto>(alert);
        }
    }
}
