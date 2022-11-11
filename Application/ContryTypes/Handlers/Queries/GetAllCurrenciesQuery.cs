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
    public class GetAllCurrenciesQueryRequest : IRequest<List<GetCurrencyListDTO>>
    {
    }

    public class GetAllCurrenciesQueryHandler : IRequestHandler<GetAllCurrenciesQueryRequest, List<GetCurrencyListDTO>>
    {
        private readonly ICountryRepository Repository;
        private readonly IMapper Mapper;

        public GetAllCurrenciesQueryHandler(ICountryRepository Repository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
        }

        public async Task<List<GetCurrencyListDTO>> Handle(GetAllCurrenciesQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await Repository.GetAllCountries();
            return Mapper.Map<List<GetCurrencyListDTO>>(result);
        }
    }
}
