using Application.DTOs.Alerts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AlertsTypes.Requests.Queries
{
    public class GetAlertDetailsRequest : IRequest<AlertDto>
    {
        public int AlertId { get; set; }
    }
}
