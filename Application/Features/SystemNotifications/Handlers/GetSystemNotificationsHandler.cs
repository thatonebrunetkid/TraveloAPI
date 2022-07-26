using Application.DTOs.SystemNotofications;
using Application.Features.SystemNotifications.Requests.Queries;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.SystemNotifications.Handlers
{
    public class GetSystemNotificationsHandler : IRequestHandler<GetSystemNotificationsRequest, List<GetSystemNotificationsDto>>
    {
        private readonly ISystemNotificationsRepository _SystemNotificationsRepository;
        private readonly IMapper _Mapper;

        public GetSystemNotificationsHandler(ISystemNotificationsRepository SystemNotificationsRepository, IMapper Mapper)
        {
            _SystemNotificationsRepository = SystemNotificationsRepository;
            _Mapper = Mapper;
        }

        public async Task<List<GetSystemNotificationsDto>> Handle(GetSystemNotificationsRequest request, CancellationToken cancellationToken)
        {
            var Notifications = await _SystemNotificationsRepository.GetCurrentSystemNotifications();
            return _Mapper.Map<List<GetSystemNotificationsDto>>(Notifications);
        }
    }
}
