using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using MediatR;

namespace Application.UserTypes.Handlers.Queries
{
    public class ValidatePropertyAccessQuerieRequest : IRequest<bool>
    {
        public string token { get; set; }
        public int UserId { get; set; }
    }

    public class ValidatePropertyAccessQuerieHandler : IRequestHandler<ValidatePropertyAccessQuerieRequest, bool>
    {
        private readonly IAuthorisationHelpers AuthorisationHelpers;

        public ValidatePropertyAccessQuerieHandler(IAuthorisationHelpers AuthorisationHelpers)
        {
            this.AuthorisationHelpers = AuthorisationHelpers;
        }

        public async Task<bool> Handle(ValidatePropertyAccessQuerieRequest request, CancellationToken cancellationToken)
        {
            return AuthorisationHelpers.ValidatePropertyAuthorization(request.token, request.UserId);
        }
    }
}

