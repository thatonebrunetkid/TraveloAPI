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
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RefreshPasswordExecuteCommandHandler : IRequestHandler<RefreshPasswordExecuteCommandRequest, HttpStatusCode>
    {
        private readonly IUserRepository Repository;

        public RefreshPasswordExecuteCommandHandler(IUserRepository Repository)
        {
            this.Repository = Repository;
        }

        public async Task<HttpStatusCode> Handle(RefreshPasswordExecuteCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new RefreshPasswordDtoValidator();
            var response = new BaseCommandResponse();
            var validatorResult = await validator.ValidateAsync(new RegreshPasswordExecuteDTO { Email = request.Email, Password = request.Password });
            if(!validatorResult.IsValid)
            {
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
                response.Success = false;
                response.Message = "Something went wrong. Check validation message";
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return await Repository.RefreshPassword(request.Email, request.Password);
        }
    }
}
