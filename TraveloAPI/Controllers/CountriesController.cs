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
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public CountriesController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [Route("Search/{phrase}")]
        [HttpGet]
        public async Task<ActionResult<List<GetCountriesNamesRequestDto>>> CountriesSearch(string phrase)
        {
            var names = await _Mediator.Send(new GetCountriesNamesRequest { Phrase = phrase });
            if (names.Count == 0) return NoContent();
            return names;
        }

        [Route("{userId}/Map")]
        [HttpGet]
        public async Task<ActionResult<List<CountriesISOCodesDto>>> CountriesForMap(int userId)
        {
            var codes = await _Mediator.Send(new GetCountriesISOCodesForMapRequest { UserId = userId });
            return codes;
        }
    }
}
