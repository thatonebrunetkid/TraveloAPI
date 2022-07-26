using Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserTypes.Requests
{
    public class GetUserDetailsRequest : IRequest<UserNoIDDTO>
    { 
        public int Id { get; set; }
    }
}
