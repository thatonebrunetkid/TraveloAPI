using Application.DTOs.User;
using Application.Features.UserTypes.Requests;
using Application.Features.UserTypes.Requests.User.Commands;
using Application.Features.UserTypes.Requests.User.Queries;
using Application.Persistence.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("HEALTH")]
        [HttpGet]
        public ActionResult Health()
        {
            return Ok("Service is up");
        }

        [Route("GET/DETAILS")]
        [HttpGet()]
        public async Task<ActionResult<UserNoIDDTO>> GetUser([FromQuery] int id)
        {
            var user = await _mediator.Send(new GetUserDetailsRequest { Id = id});
            return Ok(user);
        }

        [Route("ADD")]
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] CreateUserDto user)
        {
            var command = new CreateUserCommand { createUserDto = user };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Route("RefreshPasswordGet")]
        [HttpPost]
        public async Task<System.Net.HttpStatusCode> GetRefreshPasswordLink([FromBody] RefreshPasswordGetDTO email)
        {
            var result = await _mediator.Send(new GetRefreshLinkRequest { Email = email.Email });
            return result;
        }

        [Route("RefreshPasswordSet")]
        [HttpPost()]
        public async Task<System.Net.HttpStatusCode> SetRefreshPassword([FromBody] RefreshPasswordCommandRequest request)
        {
            var result = await _mediator.Send(new RefreshPasswordCommandRequest { Email = request.Email, Password = request.Password });
            return result;
        }




    }
}
