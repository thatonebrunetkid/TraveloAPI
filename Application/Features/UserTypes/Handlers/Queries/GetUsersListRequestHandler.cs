using Application.DTOs.User;
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
    public class GetUsersListRequestHandler : IRequestHandler<GetUsersListRequest, List<AllSusersDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<AllSusersDto>> Handle(GetUsersListRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<AllSusersDto>>(users);
        }
    }
}
