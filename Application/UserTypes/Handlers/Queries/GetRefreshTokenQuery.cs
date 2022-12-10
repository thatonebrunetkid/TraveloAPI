using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using MediatR;

namespace Application.UserTypes.Handlers.Queries
{
    public class GetRefreshTokenQueryRequest : IRequest<string>
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }

    public class GetRefreshTokenQueryHandler : IRequestHandler<GetRefreshTokenQueryRequest, string>
    {
        private readonly IAuthorisationHelpers AuthorisationHelpers;

        public GetRefreshTokenQueryHandler(IAuthorisationHelpers AuthorisationHelpers)
        {
            this.AuthorisationHelpers = AuthorisationHelpers;
        }

        public async Task<string> Handle(GetRefreshTokenQueryRequest request, CancellationToken cancellationToken)
        {
            return AuthorisationHelpers.GetRefreshToken(request.Token, request.UserId);
        }
    }
}

