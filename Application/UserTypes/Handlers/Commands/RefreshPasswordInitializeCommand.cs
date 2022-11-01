using Application.Common;
using Application.Models;
using Application.UserTypes.Contracts;
using AutoMapper;
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
    public class RefreshPasswordInitializeRequest : IRequest<HttpStatusCode>
    {
        public string Email { get; set; }
    }

    public class RefreshPasswordInitializeHandler : IRequestHandler<RefreshPasswordInitializeRequest, HttpStatusCode>
    {
        private readonly IUserRepository Repository;
        private readonly IEmailSender EmailSender;

        public RefreshPasswordInitializeHandler(IUserRepository Repository, IMapper Mapper, IEmailSender EmailSender)
        {
            this.Repository = Repository;
            this.EmailSender = EmailSender;
        }

        public async Task<HttpStatusCode> Handle(RefreshPasswordInitializeRequest request, CancellationToken cancellationToken)
        {
            if (Repository.CheckEmail(request.Email))
            {
                var email = new Email
                {
                    To = request.Email,
                    HtmlBody = $"Hi, we already recieved information about password change request, please click the link: link?{request.Email}",
                    PlainText = "",
                    Subject = "Password Change"
                };

                await EmailSender.SendEmail(email);
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
