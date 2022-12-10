using Application.TravelTypes.Commands;
using Application.TravelTypes.Queries;
using Application.UserTypes.Handlers.Queries;
using Domain.Common.DTO;
using Domain.OweSinglePayment.DTO;
using Domain.Travels.DTO;
using Domain.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("{UserId}")]
    [Authorize]
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
            Request.Headers.TryGetValue("Authorization", out StringValues authToken);
            if (await Mediator.Send(new ValidatePropertyAccessQuerieRequest { token = authToken, UserId = UserId }))
            {
                var result = await Mediator.Send(new GetAllTravelsQuerieRequest { UserId = UserId });
                if (result.Count == 0 || result == null) return NotFound();
                Response.Headers.Add("RefreshToken", await Mediator.Send(new GetRefreshTokenQueryRequest { Token = authToken, UserId = UserId }));
                return Ok(result);
            }
            else return Unauthorized();
            
        }

        [Route("Travels/Dashboard/Calendar")]
        [HttpGet]
        public async Task<ActionResult<List<TravelDashboardCalendarDTO>>> GetTravelsForDashboardCalendar(int UserId)
        {
            Request.Headers.TryGetValue("Authorization", out StringValues authToken);
            if (await Mediator.Send(new ValidatePropertyAccessQuerieRequest { token = authToken, UserId = UserId }))
            {
                var result = await Mediator.Send(new GetTravelsForDashboardCalendarQuerieRequest { UserId = UserId });
                if (result.Count == 0 || result == null) return NoContent();
                Response.Headers.Add("RefreshToken", await Mediator.Send(new GetRefreshTokenQueryRequest { Token = authToken, UserId = UserId }));
                return Ok(result);
            }
            else return Unauthorized();
        }

        [Route("Travels/Calendar")]
        [HttpGet]
        public async Task<ActionResult<List<TravelDashboardCalendarDTO>>> GetAllTravelsForCalendar(int UserId)
        {
            Request.Headers.TryGetValue("Authorization", out StringValues authToken);
            if (await Mediator.Send(new ValidatePropertyAccessQuerieRequest { token = authToken, UserId = UserId }))
            {
                var result = await Mediator.Send(new GetAllTravelsForEntireCalendarQuerieRequest { UserId = UserId });
                if (result.Count == 0 || result == null) return NoContent();
                Response.Headers.Add("RefreshToken", await Mediator.Send(new GetRefreshTokenQueryRequest { Token = authToken, UserId = UserId }));
                return Ok(result);
            }
            else return Unauthorized();
            
        }

        [Route("Travels/Upcoming")]
        [HttpGet]
        public async Task<ActionResult<GetUpcomingTravelDTO>> GetUpcomingTravel(int UserId)
        {
            Request.Headers.TryGetValue("Authorization", out StringValues authToken);
            if (await Mediator.Send(new ValidatePropertyAccessQuerieRequest { token = authToken, UserId = UserId }))
            {
                var result = await Mediator.Send(new GetUpcomingTravelQuerieRequest { UserId = UserId });
                if (result is null) return NoContent();
                Response.Headers.Add("RefreshToken", await Mediator.Send(new GetRefreshTokenQueryRequest { Token = authToken, UserId = UserId }));
                return Ok(result);
            }
            else return Unauthorized();
            
        }

        [Route("Travels/{TravelId}/Payers")]
        [HttpGet]
        public async Task<ActionResult<List<GetOweSinglePayersDTO>>> GetTravelPayers(int TravelId, int UserId)
        {
            Request.Headers.TryGetValue("Authorization", out StringValues authToken);
            if (await Mediator.Send(new ValidatePropertyAccessQuerieRequest { token = authToken, UserId = UserId }))
            {
                var result = Mediator.Send(new GetPayersNameQuerieRequest { TravelId = TravelId });
                if (result is null) return StatusCode(500);
                if (result.Result.Count == 0) return NoContent();
                Response.Headers.Add("RefreshToken", await Mediator.Send(new GetRefreshTokenQueryRequest { Token = authToken, UserId = UserId }));
                return Ok(result.Result);
            }
            else return Unauthorized();
                
        }

        [Route("Travels/{TravelId}")]
        [HttpGet]
        public async Task<ActionResult<AddNewTravelDTO>> GetParticularTravel(int TravelId, int UserId)
        {
            Request.Headers.TryGetValue("Authorization", out StringValues authToken);
            if (await Mediator.Send(new ValidatePropertyAccessQuerieRequest { token = authToken, UserId = UserId }))
            {
                var result = await Mediator.Send(new GetParticularTravelQuerieRequest { TravelId = TravelId });
                if (result is null) return NotFound();
                Response.Headers.Add("RefreshToken", await Mediator.Send(new GetRefreshTokenQueryRequest { Token = authToken, UserId = UserId }));
                return Ok(result);
            }
            else return Unauthorized();
                
        }

        [Route("Travels/Add")]
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> AddParticularTravel([FromBody] AddNewTravelDTO TravelRequest, int UserId)
        {
            Request.Headers.TryGetValue("Authorization", out StringValues authToken);
            if (await Mediator.Send(new ValidatePropertyAccessQuerieRequest { token = authToken, UserId = UserId }))
            {
                var result = await Mediator.Send(new AddNewTravelCommandRequest { Request = TravelRequest, UserId = UserId });
                Response.Headers.Add("RefreshToken", await Mediator.Send(new GetRefreshTokenQueryRequest { Token = authToken, UserId = UserId }));
                return result;
            }
            else return Unauthorized();
               
        }
    }
}
