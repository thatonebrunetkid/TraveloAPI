using Application.ContryTypes.Contracts;
using Application.TravelTypes.Contracts;
using AutoMapper;
using Domain.Country.DTO;
using Domain.Country.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ContryTypes.Handlers.Queries
{
    public class GetCountriesForMapQuerieRequest : IRequest<List<CountryISOCodeDTO>>
    {
        public int UserId { get; set; }
    }

    public class GetCountriesForMapQuerieHandler : IRequestHandler<GetCountriesForMapQuerieRequest, List<CountryISOCodeDTO>>
    {
        private readonly ICountryRepository Repository;
        private readonly ITravelRepository TravelsRepository;
        private readonly IMapper Mapper;

        public GetCountriesForMapQuerieHandler(ICountryRepository Repository, ITravelRepository TravelRepository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.TravelsRepository = TravelRepository;
            this.Mapper = Mapper;
        }

        public async Task<List<CountryISOCodeDTO>> Handle(GetCountriesForMapQuerieRequest request, CancellationToken cancellationToken)
        {
            var Travels = TravelsRepository.GetAllTravels(request.UserId).Result.Where(e => e.EndDate < DateTime.Now);
            List<Country> Countries = new List<Country>();

            foreach (var Travel in Travels)
                Countries.Add(Repository.GetCountryInfo(Travel.CountryId).Result);

            return Mapper.Map<List<CountryISOCodeDTO>>(Countries.Distinct());
        }
    }
}
