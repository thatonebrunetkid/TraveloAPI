using Application.DictionaryTypes.Handlers.Queries;
using Domain.Dictionary.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly IMediator Mediator;

        public DictionaryController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [Route("Dictionaries")]
        [HttpGet]
        public async Task<ActionResult<GetDictionariesDTO>> GetAllDictionaries()
        {
            var Dictionaries = await Mediator.Send(new GetDictionariesQuerieRequest());
            if (Dictionaries.Dictionaries.Count == 0 || Dictionaries.Dictionaries == null) return NotFound();
            return Ok(Dictionaries);
        }
    }
}
