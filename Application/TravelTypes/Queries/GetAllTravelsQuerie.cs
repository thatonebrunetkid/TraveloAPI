using Application.ContryTypes.Contracts;
using Application.Flag.Contracts;
using Application.TravelTypes.Contracts;
using AutoMapper;
using Domain.Alert.DTO;
using Domain.Country.Entities;
using Domain.Travels.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TravelTypes.Queries
{
    public class GetAllTravelsQuerieRequest : IRequest<List<TravelDTO>>
    {
        public int UserId { get; set; }
    }

    public class GetAllTravelsQuerieHandler : IRequestHandler<GetAllTravelsQuerieRequest, List<TravelDTO>>
    {
        private readonly ITravelRepository Repository;
        private readonly ICountryRepository CountryRepository;
        private readonly IFlagRepository FlagRepository;
        private readonly IMapper Mapper;

        public GetAllTravelsQuerieHandler(ITravelRepository Repository, ICountryRepository CountryRepository, IFlagRepository FlagRepository,IMapper Mapper)
        {
            this.Repository = Repository;
            this.CountryRepository = CountryRepository;
            this.FlagRepository = FlagRepository;
            this.Mapper = Mapper;
        }

        public async Task<List<TravelDTO>> Handle(GetAllTravelsQuerieRequest request, CancellationToken cancellationToken)
        {
            var travels = await Repository.GetAllTravels(request.UserId);
            List<TravelDTO> Result = new List<TravelDTO>();
            
            foreach(var travel in travels)
            {
                Result.Add(new TravelDTO
                {
                    TravelId = travel.TravelId,
                    Name = travel.Name,
                    Destination = travel.Destination,
                    StartDate = travel.StartDate,
                    EndDate = travel.EndDate,
                    FlagURL = await FlagRepository.GetFlag((await CountryRepository.GetCountryInfo(travel.CountryId)).FlagId)
                });
            }
            return Mapper.Map<List<TravelDTO>>(Result);
        }
    }
}
