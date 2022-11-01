using Application.ContryTypes.Handlers.Queries;
using Domain.Country.DTO;
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
        private readonly IMediator Mediator;

        public CountriesController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [Route("Search/{phrase}")]
        [HttpGet]
        public async Task<ActionResult<List<CountryNameDTO>>> GetCountriesList(string phrase)
        {
            var names = await Mediator.Send(new GetCountriesNamesQuerieRequest { Phrase = phrase });
            if (names.Count == 0) return NotFound();
            return names;
        }

        [Route("{UserId}/Map")]
        [HttpGet]
        public async Task<ActionResult<List<CountryISOCodeDTO>>> GetTravelsForMap(int UserId)
        {
            return await Mediator.Send(new GetCountriesForMapQuerieRequest { UserId = UserId });
        }
    }
}
