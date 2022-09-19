using Application.DTOs.Dictionary;
using Application.Features.Dictionary.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public DictionaryController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [Route("Dictionaries")]
        [HttpGet]
        public async Task<ActionResult<GetDictionariesDTO>> GetAllDictionary()
        {
            var Dictionaries = await _Mediator.Send(new GetDictionaryRequest());
            if (Dictionaries.Dictionaries.Count == 0) return NoContent();
            return Ok(Dictionaries);
        }
    }

}
