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
    public class RefreshPasswordExecuteCommandRequest : IRequest<BaseCommandResponse>
    {
        public string ActivityId { get; set; }
        public string Password { get; set; }
    }

    public class RefreshPasswordExecuteCommandHandler : IRequestHandler<RefreshPasswordExecuteCommandRequest, BaseCommandResponse>
    {
        private readonly IUserRepository Repository;
        private readonly IRedisHandler RedisHandler;

        public RefreshPasswordExecuteCommandHandler(IUserRepository Repository, IRedisHandler RedisHandler)
        {
            this.Repository = Repository;
            this.RedisHandler = RedisHandler;
        }

        public async Task<BaseCommandResponse> Handle(RefreshPasswordExecuteCommandRequest request, CancellationToken cancellationToken)
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

            var cacheResult = await RedisHandler.GetData(request.ActivityId);
            var cacheSplitter = cacheResult.Split("|date|");
            var email = cacheSplitter[0];
            var date = cacheSplitter[1];
            if (email != string.Empty && email != null && DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc) < DateTime.SpecifyKind(DateTime.Parse(date).AddMinutes(10), DateTimeKind.Utc))
            {
                if(await Repository.RefreshPassword(email, request.Password) == HttpStatusCode.OK)
                {
                    response = new BaseCommandResponse
                    {
                        Success = true,
                        Message = "Succeed",
                        StatusCode = HttpStatusCode.OK
                    };

                    RedisHandler.DeleteData(request.ActivityId);
                }
                else
                {
                    response = new BaseCommandResponse
                    {
                        Success = false,
                        Message = "Operation Exceeded",
                        StatusCode = HttpStatusCode.Unauthorized
                    };
                }
            }
            else
            {
                response = new BaseCommandResponse()
                {
                    Success = false,
                    Message = "Internal Server Error",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            return response;
        }
    }
}
