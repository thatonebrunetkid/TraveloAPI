﻿using Application.DTOs.Validations;
using Application.Exceptions;
using Application.Features.UserTypes.Requests.User.Commands;
using Application.Models;
using Application.Persistence.Contracts;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserTypes.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUserDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.createUserDto);

            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var user = _mapper.Map<User>(new User()
            {
                Name = request.createUserDto.Name,
                Surname = request.createUserDto.Surname,
                PhoneNumber = request.createUserDto.PhoneNumber,
                Email = request.createUserDto.Email,
                Password = request.createUserDto.Password,
                PasswordDateUpdated = DateTime.Now,
            });
            user = await _userRepository.Add(user);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = user.UserId;

            var email = new Email
            {
                To = request.createUserDto.Email,
                HtmlBody = $"<strong> Hi {request.createUserDto.Name} welcome to Travelo. </strong> <br> We are very grateful to have joined us. If you have any question please contact us on travelodeveloper@gmail.com",
                Subject = "Welcome to Travelo Family",
                PlainText = ""
            };

            try
            {
                await _emailSender.SendEmail(email);
            }catch(Exception)
            {
                //
            }

            return response;
        }
    }
}
    

 
