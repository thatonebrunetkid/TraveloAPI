using Application.DTOs.User;
using Application.Features.UserTypes.Requests;
using Application.Features.UserTypes.Requests.User.Commands;
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

        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var users = await _mediator.Send(new GetUsersListRequest());
            return users;
        }

        [Route("GetUser")]
        [HttpGet()]
        public async Task<ActionResult<UserNoIDDTO>> GetUser([FromQuery] int id)
        {
            var user = await _mediator.Send(new GetUserDetailsRequest { Id = id});
            return Ok(user);
        }

        [Route("AddUser")]
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] CreateUserDto user)
        {
            var command = new CreateUserCommand { createUserDto = user };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
