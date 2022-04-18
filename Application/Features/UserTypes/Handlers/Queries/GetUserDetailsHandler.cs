using Application.DTOs.User;
using Application.Exceptions;
using Application.Features.UserTypes.Requests;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserTypes.Handlers.Queries
{
    public class GetUserDetailsHandler : IRequestHandler<GetUserDetailsRequest, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailsHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserDetailsRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id);

            if (user == null)
                throw new NotFoundException(nameof(user), request.Id);

            return _mapper.Map<UserDTO>(user);
        }
    }
}
