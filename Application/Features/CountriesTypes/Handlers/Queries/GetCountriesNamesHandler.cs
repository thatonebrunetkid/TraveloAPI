using Application.DTOs.Countries;
using Application.Features.CountriesTypes.Requests.Queries;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CountriesTypes.Handlers.Queries
{
    public class GetCountriesNamesHandler : IRequestHandler<GetCountriesNamesRequest, List<GetCountriesNamesRequestDto>>
    {
        private readonly ICountriesRepository _CountriesRepository;
        private readonly IMapper _Mapper;

        public GetCountriesNamesHandler(ICountriesRepository CountriesRepository, IMapper Mapper)
        {
            _CountriesRepository = CountriesRepository;
            _Mapper = Mapper;
        }

        public async Task<List<GetCountriesNamesRequestDto>> Handle(GetCountriesNamesRequest request, CancellationToken cancellationToken)
        {
            var Countries = await _CountriesRepository.GetCountriesNamesList(request.Phrase);
            return _Mapper.Map<List<GetCountriesNamesRequestDto>>(Countries);
        }
    }
}
