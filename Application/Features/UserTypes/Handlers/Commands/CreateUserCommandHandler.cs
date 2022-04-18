using Application.DTOs.Validations;
using Application.Exceptions;
using Application.Features.UserTypes.Requests.User.Commands;
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

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
                LastLogin = DateTime.Now
            });
            user = await _userRepository.Add(user);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = user.Id;

            return response;
        }
    }
}
    

 
