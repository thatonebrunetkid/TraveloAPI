﻿using Application.TravelTypes.Queries;
using Domain.Travels.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("{UserId}")]
    public class TravelController : ControllerBase
    {
        private readonly IMediator Mediator;

        public TravelController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [Route("Travels")]
        [HttpGet]
        public async Task<ActionResult<List<TravelDTO>>> GetAllTravels(int UserId)
        {
            var result = await Mediator.Send(new GetAllTravelsQuerieRequest { UserId = UserId });
            if (result.Count == 0 || result == null) return NotFound();
            return Ok(result);
        }

        [Route("Travels/Dashboard/Calendar")]
        [HttpGet]
        public async Task<ActionResult<List<TravelDashboardCalendarDTO>>> GetTravelsForDashboardCalendar(int UserId)
        {
            var result = await Mediator.Send(new GetTravelsForDashboardCalendarQuerieRequest { UserId = UserId});
            if (result.Count == 0 || result == null) return NoContent();
            return Ok(result);
        }

        [Route("Travels/Calendar")]
        [HttpGet]
        public async Task<ActionResult<List<TravelDashboardCalendarDTO>>> GetAllTravelsForCalendar(int UserId)
        {
            var result = await Mediator.Send(new GetAllTravelsForEntireCalendarQuerieRequest { UserId = UserId });
            if (result.Count == 0 || result == null) return NoContent();
            return Ok(result);
        }

        [Route("Travels/Upcoming")]
        [HttpGet]
        public async Task<ActionResult<GetUpcomingTravelDTO>> GetUpcomingTravel(int UserId)
        {
            var result = await Mediator.Send(new GetUpcomingTravelQuerieRequest { UserId = UserId });
            if (result is null) return NoContent();
            return Ok(result);
        }
    }
}
