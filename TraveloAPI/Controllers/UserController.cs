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
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("Health")]
        [HttpGet]
        public ActionResult Health()
        {
            return Ok("Service is up");
        }

        [Route("{UserId}/Details")]
        [HttpGet]
        public async Task<ActionResult<UserNoIDDTO>> GetUser(int UserId)
        {
            var user = await _mediator.Send(new GetUserDetailsRequest { Id =UserId});
            return Ok(user);
        }

        [Route("New")]
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] CreateUserDto user)
        {
            var command = new CreateUserCommand { createUserDto = user };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Route("RefreshPasswordInitialize")]
        [HttpPost]
        public async Task<System.Net.HttpStatusCode> GetRefreshPasswordLink([FromBody] RefreshPasswordGetDTO email)
        {
            var result = await _mediator.Send(new GetRefreshLinkRequest { Email = email.Email });
            return result;
        }

        [Route("RefreshPasswordExecute")]
        [HttpPost()]
        public async Task<System.Net.HttpStatusCode> SetRefreshPassword([FromBody] RefreshPasswordCommandRequest request)
        {
            var result = await _mediator.Send(new RefreshPasswordCommandRequest { Email = request.Email, Password = request.Password });
            return result;
        }




    }
}
