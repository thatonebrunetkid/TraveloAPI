using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.UserTypes.Contracts;
using Domain.Common.DTO;
using Domain.User.DTO;
using Domain.User.Validations;
using MediatR;

namespace Application.UserTypes.Handlers.Commands
{
    public class ChangePasswordCommandRequest : IRequest<HttpStatusCode>
    {
        public int UserId { get; set; }
        public RegreshPasswordExecuteDTO Request { get; set; }
    }

    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommandRequest, HttpStatusCode>
    {
        private readonly IUserRepository Repository;

        public ChangePasswordCommandHandler(IUserRepository Repository)
        {
            this.Repository = Repository;
        }

        public async Task<HttpStatusCode> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new RefreshPasswordDtoValidator();
            var response = new BaseCommandResponse();
            var validatorResult = await validator.ValidateAsync(new RegreshPasswordExecuteDTO { Password = request.Request.Password });
            if (validatorResult.IsValid)
            {
                await Repository.ChangePassword(request.UserId, request.Request.Password);
                return HttpStatusCode.OK;
            }
            else
                return HttpStatusCode.BadRequest;
        }
    }
}

