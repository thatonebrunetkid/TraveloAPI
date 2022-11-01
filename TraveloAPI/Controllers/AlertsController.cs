using Application.AlertTypes.Handlers.Queries;
using Domain.Alert.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly IMediator Mediator;

        public AlertsController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [Route("All")]
        [HttpGet]
        public async Task<ActionResult<List<AllAlertsDTO>>> GetAllAlerts()
        {
            var alerts = await Mediator.Send(new GetAllAlertsQuerieRequest());
            if (alerts.Count == 0) return NotFound();
            return alerts;
        }

    }
}
