using Application.ContryTypes.Handlers.Queries;
using Domain.Country.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator Mediator;

        public CountriesController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [Route("Search/{phrase}")]
        [HttpGet]
        [AllowAnonymous]
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

        [Route("ServicePhones")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetCountryServicePhonesDTO>>> GetServicePhones()
        {
            var result = await Mediator.Send(new GetCountriesServicePhonesQuerieRequest());
            if (result.Count == 0) return NoContent();
            if (result is null) return StatusCode(500);
            return Ok(result);
        }

        [Route("Currencies")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetCurrencyListDTO>>> GetCurrencyList()
        {
            var result = await Mediator.Send(new GetAllCurrenciesQueryRequest());
            if (result.Count == 0) return NoContent();
            if (result is null) return StatusCode(500);
            return Ok(result);
        }
    }
}
