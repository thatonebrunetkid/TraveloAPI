using Application.DTOs.Countries;
using Application.Exceptions;
using Application.Features.CountriesTypes.Requests.Queries;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CountriesTypes.Handlers.Queries
{
    public class GetCountryIdByNameHandler : IRequestHandler<GetCountryByNameRequest, GetCountryNameByIdDto>
    {
        private readonly ICountriesRepository _CountriesRepository;
        private readonly IMapper _Mapper;

        public GetCountryIdByNameHandler(ICountriesRepository CountriesRepository, IMapper Mapper)
        {
            _CountriesRepository = CountriesRepository;
            _Mapper = Mapper;
        }
        public async Task<GetCountryNameByIdDto> Handle(GetCountryByNameRequest request, CancellationToken cancellationToken)
        {
            var CountryId = await _CountriesRepository.GetCountryIdByName(request.CountryName);
            if (CountryId == null)
                throw new NotFoundException(nameof(CountryId), request.CountryName);
            return _Mapper.Map<GetCountryNameByIdDto>(CountryId);
        }
    }
}
