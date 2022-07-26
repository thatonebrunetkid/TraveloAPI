using Application.DTOs.Travel;
using Application.Features.TravelTypes.Requests.Queries;
using Application.Features.TravelTypes.Requests.Travel.Commands;
using Application.Features.TravelTypes.Requests.Travel.Queries;
using Application.Features.UserTypes.Requests.Travel.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public TravelsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [Route("GET/ALL")]
        [HttpGet]
        public async Task<ActionResult<List<AllTravelsDTO>>> Get([FromQuery] int UserId)
        {
            var Travels = await _Mediator.Send(new GetTravelListRequest { UserId = UserId});
            if(Travels == null)
                return NotFound();
            return Ok(Travels);
        }

        [Route("ADD")]
        [HttpPost]
        public async Task<ActionResult> AddNew([FromBody] AddNewTravelDto Travel)
        {
            var command = new AddNewTravelRequest { AddNewTravelDto = Travel };
            var response = await _Mediator.Send(command);
            return Ok(response);
        }

        [Route("DASHBOARD/GET/CALENDAR")]
        [HttpGet]
        public async Task<ActionResult<List<GetTravelDatesFromCurrentMonthDto>>> GetTravelsDatesFromCurrentMonth([FromQuery] int UserId)
        {
            var Dates = await _Mediator.Send(new GetTravelDatesFromCurrentMonthRequest() { UserId = UserId});
            if (Dates.Count == 0) return NoContent();
            return Ok(Dates);
        }

        [Route("DASHBOARD/GET/UPCOMINGTRAVEL")]
        [HttpGet]
        public async Task<ActionResult<GetCurrentTravelInformationDto>> GetCurrentTravelInfo([FromQuery] int UserId)
        {
            var Travel = await _Mediator.Send(new GetCurrentTravelInformationRequest() { UserId = UserId});
            if (Travel == null) return NotFound();
            return Ok(Travel);
        }

        [Route("CALENDAR/GET/DATES")]
        [HttpGet]
        public async Task<ActionResult<List<GetTravelDatesFromCurrentMonthDto>>> GetAllTravelsDates([FromQuery] int UserId)
        {
            var Dates = await _Mediator.Send(new GetAllTravelDatesRequest() { UserId = UserId });
            if (Dates.Count == 0) return NoContent();
            return Ok(Dates);
        }
    }
}
