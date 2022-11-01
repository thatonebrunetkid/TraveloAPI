using Application.UserTypes.Contracts;
using AutoMapper;
using Domain.Alert.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AlertTypes.Handlers.Queries
{
    public class GetAllAlertsQuerieRequest : IRequest<List<AllAlertsDTO>>
    {

    }

    public class GetAllAlertsQuerieHandler : IRequestHandler<GetAllAlertsQuerieRequest, List<AllAlertsDTO>>
    {
        private readonly IAlertRepository Repository;
        private readonly IMapper Mapper;

        public GetAllAlertsQuerieHandler(IAlertRepository Repository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
        }

        public async Task<List<AllAlertsDTO>> Handle(GetAllAlertsQuerieRequest request, CancellationToken cancellationToken)
        {
            var alerts = await Repository.GetAllAlerts();
            return Mapper.Map<List<AllAlertsDTO>>(alerts);
        }
    }
}
