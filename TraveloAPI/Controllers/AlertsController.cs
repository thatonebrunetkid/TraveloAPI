using Application.DTOs.Alerts;
using Application.Features.AlertsTypes.Requests.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AlertsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }


        [Route("GET/ALL")]
        [HttpGet]
        public async Task<ActionResult<List<AlertDto>>> GetAllAlerts()
        {
            var Alerts = await _Mediator.Send(new GetAllAlertsRequest());
            if (Alerts.Count == 0) return NoContent();
            return Alerts;
          
        }
    }
}
