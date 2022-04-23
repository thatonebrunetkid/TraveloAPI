using Application.DTOs.Travel;
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
            return Ok(Travels);
        }
    }
}
