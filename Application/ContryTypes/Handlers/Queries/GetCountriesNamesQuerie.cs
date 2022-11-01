using Application.ContryTypes.Contracts;
using AutoMapper;
using Domain.Country.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ContryTypes.Handlers.Queries
{
    public class GetCountriesNamesQuerieRequest : IRequest<List<CountryNameDTO>>
    {
        public string Phrase { get; set; }
    }

    public class GetCountriesNamesQuerieHandler : IRequestHandler<GetCountriesNamesQuerieRequest, List<CountryNameDTO>>
    {
        private readonly ICountryRepository Repository;
        private readonly IMapper Mapper;

        public GetCountriesNamesQuerieHandler(ICountryRepository Repository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
        }

        public async Task<List<CountryNameDTO>> Handle(GetCountriesNamesQuerieRequest request, CancellationToken cancellationToken)
        {
            var countries = await Repository.GetCountryNames(request.Phrase);
            return Mapper.Map<List<CountryNameDTO>>(countries);
        }
    }
}
