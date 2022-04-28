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

        [Route("GET/ALL")]
        [HttpGet]
        public async Task<ActionResult<List<Countries>>> GetAllCountries()
        {
            return await _Mediator.Send(new GetAllCountriesRequest());
        }

        [Route("GET/DEATILS")]
        [HttpGet]
        public async Task<ActionResult<CountriesDto>> GetCountryDetails([FromQuery] int id)
        {
            return await _Mediator.Send(new GetCountryDetailsRequest { CountryId = id });
        }
    }
}
