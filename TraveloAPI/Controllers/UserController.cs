﻿using Application.UserTypes.Handlers.Commands;
using Application.UserTypes.Handlers.Queries;
using Domain.User.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator Mediator;

        public UserController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [Route("New")]
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] CreateUserDTO user)
        {
            var command = new CreateUserCommandRequest { CreateUserDTO = user };
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [Route("RefreshPasswordInitialize")]
        [HttpPost]
        public async Task<HttpStatusCode> RefreshPasswordInitialize([FromBody] RefreshPasswordInitializeDTO request)
        {
            var result = await Mediator.Send(new RefreshPasswordInitializeRequest { Email = request.Email });
            return result;
        }

        [Route("RefreshPasswordExecute/{ActivityId}")]
        [HttpPost]
        public async Task<HttpStatusCode> RefreshPasswordExecute([FromBody] RegreshPasswordExecuteDTO request, string ActivityId)
        {
            var result = await Mediator.Send(new RefreshPasswordExecuteCommandRequest {Password = request.Password, ActivityId = ActivityId});
            return result;
        }

        [Route("{UserId}")]
        [HttpGet]
        public async Task<ActionResult<GetUserDataDTO>> GetUserData(int UserId)
        {
            var result = await Mediator.Send(new GetUserDataQuerieRequest { UserId = UserId });
            if (result is null) return NotFound();
            return Ok(result);
        }
    }
}
