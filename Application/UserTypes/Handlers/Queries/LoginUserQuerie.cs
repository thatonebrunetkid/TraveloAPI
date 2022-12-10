using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.UserTypes.Contracts;
using Domain.User;
using Domain.User.DTO;
using Infrastructure.Authentication;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.UserTypes.Handlers.Queries
{
    public class LoginUserQuerieRequest : IRequest<LoginResponseDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserQuerieHandler : IRequestHandler<LoginUserQuerieRequest, LoginResponseDTO>
    {
        private readonly IUserRepository Repository;
        private readonly IRedisHandler Redis;
        private readonly IAuthorisationHelpers AuthorisationHelpers;
        
        public LoginUserQuerieHandler(IUserRepository Repository, IAuthorisationHelpers AuthorisationHelpers, IRedisHandler Redis)
        {
            this.Repository = Repository;
            this.AuthorisationHelpers = AuthorisationHelpers;
            this.Redis = Redis;
        }

        public async Task<LoginResponseDTO> Handle(LoginUserQuerieRequest request, CancellationToken cancellationToken)
        {
            var user = await Repository.CheckIfUserExist(request.Email, request.Password);

            if (user != null)
            {
                return new LoginResponseDTO
                {
                    UserId = user.UserId,
                    BearerToken = AuthorisationHelpers.GenerateToken(user.UserId)
                };
            }
            else
                return null;
        }
    }
}

