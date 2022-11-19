using Application.Common;
using Application.Models;
using Application.UserTypes.Contracts;
using Domain.Common.DTO;
using Domain.User.DTO;
using Domain.User.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserTypes.Handlers.Commands
{
    public class RefreshPasswordExecuteCommandRequest : IRequest<HttpStatusCode>
    {
        public string ActivityId { get; set; }
        public string Password { get; set; }
    }

    public class RefreshPasswordExecuteCommandHandler : IRequestHandler<RefreshPasswordExecuteCommandRequest, HttpStatusCode>
    {
        private readonly IUserRepository Repository;
        private readonly IRedisHandler RedisHandler;

        public RefreshPasswordExecuteCommandHandler(IUserRepository Repository, IRedisHandler RedisHandler)
        {
            this.Repository = Repository;
            this.RedisHandler = RedisHandler;
        }

        public async Task<HttpStatusCode> Handle(RefreshPasswordExecuteCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new RefreshPasswordDtoValidator();
            var response = new BaseCommandResponse();
            var validatorResult = await validator.ValidateAsync(new RegreshPasswordExecuteDTO { Password = request.Password });
            if(!validatorResult.IsValid)
            {
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
                response.Success = false;
                response.Message = "Something went wrong. Check validation message";
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            var email = await RedisHandler.GetData(request.ActivityId);
            if (email != string.Empty && email != null)
            {
                RedisHandler.DeleteData(request.ActivityId);
                return await Repository.RefreshPassword(email, request.Password);
            }
            else
                return HttpStatusCode.InternalServerError;
        }
    }
}
