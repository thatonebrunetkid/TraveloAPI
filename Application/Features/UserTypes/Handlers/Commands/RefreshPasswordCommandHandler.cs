using Application.DTOs.User;
using Application.DTOs.Validations;
using Application.Features.UserTypes.Requests.User.Commands;
using Application.Persistence.Contracts;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserTypes.Handlers.Commands
{
    public class RefreshPasswordCommandHandler : IRequestHandler<RefreshPasswordCommandRequest, System.Net.HttpStatusCode>
    {
        private readonly IUserRepository _userRepository;

        public RefreshPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

   
        public async Task<HttpStatusCode> Handle(RefreshPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new RefreshPasswordValidator();
            var response = new BaseCommandResponse();
            var validatorResult = await validator.ValidateAsync(new RefreshPasswordCommandDto { Email = request.Email, Password = request.Password});
            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            return await _userRepository.RefreshPassword(request.Email, request.Password);
        }
    }
}
