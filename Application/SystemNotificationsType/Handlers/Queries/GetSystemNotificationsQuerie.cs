using Application.SystemNotificationsType.Contracts;
using AutoMapper;
using Domain.SystemNotification.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SystemNotificationsType.Handlers.Queries
{
    public class GetSystemNotificationsQuerieRequest : IRequest<List<GetAllSystemNotificationsDTO>>
    {

    }

    public class GetSystemNotificationsQuerieHandler : IRequestHandler<GetSystemNotificationsQuerieRequest, List<GetAllSystemNotificationsDTO>>
    {
        private readonly ISystemNotificationRepository Repository;
        private readonly IMapper Mapper;

        public GetSystemNotificationsQuerieHandler(ISystemNotificationRepository Repository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
        }

        public async Task<List<GetAllSystemNotificationsDTO>> Handle(GetSystemNotificationsQuerieRequest request, CancellationToken cancellationToken)
        {
            var Notifications = await Repository.GetAllSystemNotifications();
            return Mapper.Map<List<GetAllSystemNotificationsDTO>>(Notifications);
        }
    }
}
