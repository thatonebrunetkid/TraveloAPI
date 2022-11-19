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
        private readonly IRedisHandler RedisHandler;

        public RefreshPasswordInitializeHandler(IUserRepository Repository, IMapper Mapper, IEmailSender EmailSender, IRedisHandler RedisHandler)
        {
            this.Repository = Repository;
            this.EmailSender = EmailSender;
            this.RedisHandler = RedisHandler;
        }

        public async Task<HttpStatusCode> Handle(RefreshPasswordInitializeRequest request, CancellationToken cancellationToken)
        {
            if (Repository.CheckEmail(request.Email))
            {
                var ActivityId = RedisHandler.PrepareActivityKey();
                var email = new Email
                {
                    To = request.Email,
                    HtmlBody = $"Hi, we already recieved information about password change request, please click the link: https://travelo.forgotPassword.com?{ActivityId}",
                    PlainText = "",
                    Subject = "Password Change"
                };

                if (RedisHandler.SetData(request.Email, ActivityId).Result)
                {
                    await EmailSender.SendEmail(email);
                    return HttpStatusCode.OK;
                }
                else
                    return HttpStatusCode.InternalServerError;
            }
            else
                return HttpStatusCode.BadRequest;
        }
    }
}
