using Application.DTOs.Countries;
using Application.Features.CountriesTypes.Requests.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public CountriesController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [Route("GET/COUNTRIES/SEARCH")]
        [HttpGet]
        public async Task<ActionResult<List<GetCountriesNamesRequestDto>>> CountriesSearch([FromQuery] string phrase)
        {
            var names = await _Mediator.Send(new GetCountriesNamesRequest { Phrase = phrase });
            if (names.Count == 0) return NoContent();
            return names;
        }
    }
}
