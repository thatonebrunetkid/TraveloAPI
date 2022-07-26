using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserTypes.Requests.User.Queries
{
    public class GetRefreshLinkRequest : IRequest<System.Net.HttpStatusCode>
    {
        public string Email { get; set; }
    }
}
