using Application.Features.UserTypes.Requests.User.Queries;
using Application.Models;
using Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserTypes.Handlers.Queries
{
    public class GetUserRefreshLinkHandler : IRequestHandler<GetRefreshLinkRequest, System.Net.HttpStatusCode>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _emailSender;

        public GetUserRefreshLinkHandler(IUserRepository userRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _emailSender = emailSender;
        }

        public async Task<HttpStatusCode> Handle(GetRefreshLinkRequest request, CancellationToken cancellationToken)
        {
            if(_userRepository.CheckEmail(request.Email))
            {
                var email = new Email
                {
                    To = request.Email,
                    HtmlBody = $"Hi, we already recieved information about password change request, please click the link: link?{request.Email}",
                    PlainText = "",
                    Subject = "Password Change"
                };

                await _emailSender.SendEmail(email);
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
