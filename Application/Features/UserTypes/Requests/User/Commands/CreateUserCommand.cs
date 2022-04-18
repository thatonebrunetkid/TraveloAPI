using Application.DTOs.User;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserTypes.Requests.User.Commands
{
    public class CreateUserCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserDto createUserDto { get; set; }
    }
}
