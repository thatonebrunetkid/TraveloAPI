﻿using Application.DTOs.SystemNotofications;
using Application.Features.SystemNotifications.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemNotificationsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public SystemNotificationsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [Route("Notifications")]
        [HttpGet]
        public async Task<ActionResult<List<GetSystemNotificationsDto>>> GetAllValidSystemNotifications()
        {
            var Notifications = await _Mediator.Send(new GetSystemNotificationsRequest());
            if (Notifications.Count == 0) return NoContent();
            return Notifications;
        }
    }
}
