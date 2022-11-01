using Application.SystemNotificationsType.Handlers.Queries;
using Domain.SystemNotification.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemNotificationsController : Controller
    {
        private readonly IMediator Mediator;

        public SystemNotificationsController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }


        [Route("Notifications")]
        [HttpGet]
        public async Task<ActionResult<List<GetAllSystemNotificationsDTO>>> GetAllNotifications()
        {
            var Notifications = await Mediator.Send(new GetSystemNotificationsQuerieRequest());
            if (Notifications.Count == 0 || Notifications == null) return NotFound();
            return Ok(Notifications);
        }
    }
}
