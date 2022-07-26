using Application.DTOs.SystemNotofications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SystemNotifications.Requests.Queries
{
    public class GetSystemNotificationsRequest : IRequest<List<GetSystemNotificationsDto>>
    {
    }
}
