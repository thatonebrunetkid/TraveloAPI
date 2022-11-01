using Application.Common;
using Application.Models;
using Application.UserTypes.Contracts;
using AutoMapper;
using Domain.Common.DTO;
using Domain.User;
using Domain.User.DTO;
using Domain.User.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserTypes.Handlers.Commands
{
    public class CreateUserCommandRequest : IRequest<BaseCommandResponse>
    {
        public CreateUserDTO CreateUserDTO { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseCommandResponse>
    {
        private readonly IUserRepository Repository;
        private readonly IMapper Mapper;
        private readonly IEmailSender EmailSender;

        public CreateUserCommandHandler(IUserRepository Repository, IMapper Mapper, IEmailSender EmailSender)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
            this.EmailSender = EmailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUserDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.CreateUserDTO);

            if(!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var user = Mapper.Map<User>(new User()
            {
                Name = request.CreateUserDTO.Name,
                Surname = request.CreateUserDTO.Surname,
                PhoneNumber = request.CreateUserDTO.PhoneNumber,
                Email = request.CreateUserDTO.Email,
                Password = request.CreateUserDTO.Password,
                PasswordDateUpdated = DateTime.Now,
                DateCreated = DateTime.Now
            });

            user = await Repository.AddNewUser(user);

            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = user.UserId;

            var email = new Email
            {
                To = request.CreateUserDTO.Email,
                HtmlBody = $"<strong> Hi {request.CreateUserDTO.Name} welcome to Travelo. </strong> <br> We are very grateful to have joined us. If you have any question please contact us on travelodeveloper@gmail.com",
                Subject = "Welcome to Travelo Family",
                PlainText = ""
            };

            try
            {
                await EmailSender.SendEmail(email);
            }catch(Exception)
            {
                //
            }

            return response;
        }
    }
}
