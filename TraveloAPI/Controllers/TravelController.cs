using Application.TravelTypes.Commands;
using Application.TravelTypes.Queries;
using Domain.Common.DTO;
using Domain.OweSinglePayment.DTO;
using Domain.Travels.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
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

        [Route("Travels/{TravelId}/Payers")]
        [HttpGet]
        public async Task<ActionResult<List<GetOweSinglePayersDTO>>> GetTravelPayers(int TravelId)
        {
            var result = Mediator.Send(new GetPayersNameQuerieRequest { TravelId = TravelId });
            if (result is null) return StatusCode(500);
            if (result.Result.Count == 0) return NoContent();
            return Ok(result.Result);
        }

        [Route("Travels/{TravelId}")]
        [HttpGet]
        public async Task<ActionResult<AddNewTravelDTO>> GetParticularTravel(int TravelId)
        {
            var result = await Mediator.Send(new GetParticularTravelQuerieRequest { TravelId = TravelId });
            if (result is null) return NotFound();
            return Ok(result);
        }

        [Route("Travels/Add")]
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> AddParticularTravel([FromBody] AddNewTravelDTO Request, int UserId)
        {
            var result = await Mediator.Send(new AddNewTravelCommandRequest { Request = Request, UserId = UserId });
            return result;
        }
    }
}
