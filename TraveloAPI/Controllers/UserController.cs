using Application.UserTypes.Handlers.Commands;
using Application.UserTypes.Handlers.Queries;
using Domain.User.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Authorize]
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
        [AllowAnonymous]
        public async Task<ActionResult> AddUser([FromBody] CreateUserDTO user)
        {
            var command = new CreateUserCommandRequest { CreateUserDTO = user };
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [Route("RefreshPasswordInitialize")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<HttpStatusCode> RefreshPasswordInitialize([FromBody] RefreshPasswordInitializeDTO request)
        {
            var result = await Mediator.Send(new RefreshPasswordInitializeRequest { Email = request.Email });
            return result;
        }

        [Route("RefreshPasswordExecute/{ActivityId}")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<HttpStatusCode> RefreshPasswordExecute([FromBody] RegreshPasswordExecuteDTO request, string ActivityId)
        {
            var result = await Mediator.Send(new RefreshPasswordExecuteCommandRequest {Password = request.Password, ActivityId = ActivityId});
            return result;
        }

        [Route("{UserId}")]
        [HttpGet]
        public async Task<ActionResult<GetUserDataDTO>> GetUserData(int UserId)
        {
            Request.Headers.TryGetValue("Authorization", out StringValues authToken);

            if (await Mediator.Send(new ValidatePropertyAccessQuerieRequest { token = authToken, UserId = UserId }))
            {
                var result = await Mediator.Send(new GetUserDataQuerieRequest { UserId = UserId });
                if (result is null) return NotFound();
                Response.Headers.Add("RefreshToken", await Mediator.Send(new GetRefreshTokenQueryRequest { Token = authToken, UserId = UserId }));
                return Ok(result);
            }
            else
                return Unauthorized();
            
        }

        [Route("{UserId}/Password/Change")]
        [HttpPost]
        public async Task<ActionResult<HttpStatusCode>> ChangePassword([FromBody] RegreshPasswordExecuteDTO request, int UserId)
        {
            Request.Headers.TryGetValue("Authorization", out StringValues authToken);
            if (await Mediator.Send(new ValidatePropertyAccessQuerieRequest { token = authToken, UserId = UserId }))
            {
                Response.Headers.Add("RefreshToken", await Mediator.Send(new GetRefreshTokenQueryRequest { Token = authToken, UserId = UserId }));
                return await Mediator.Send(new ChangePasswordCommandRequest { Request = request, UserId = UserId });

            }
            else
                return Unauthorized();
        }

        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginDTO Login)
        {
            var result = await Mediator.Send(new LoginUserQuerieRequest { Email = Login.Email, Password = Login.Password });
            if (result == null) return NotFound();
            else
                return Ok(result);
        }
    }
}
