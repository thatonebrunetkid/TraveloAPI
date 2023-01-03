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

        [Route("{CountryId}")]
        [HttpGet]
        public async Task<ActionResult<List<AllAlertsDTO>>> GetAllAlerts(int CountryId)
        {
            var alerts = await Mediator.Send(new GetAllAlertsQuerieRequest { CountryId = CountryId});
            if (alerts.Count == 0) return NotFound();
            return alerts;
        }

    }
}
