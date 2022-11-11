using Application.ContryTypes.Contracts;
using Application.ServicePhoneTypes.Contracts;
using AutoMapper;
using Domain.Country.DTO;
using Domain.ServicePhone.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ContryTypes.Handlers.Queries
{
    public class GetCountriesServicePhonesQuerieRequest : IRequest<List<GetCountryServicePhonesDTO>>
    {

    }

    public class GetCountriesServicePhonesQuerieHandler : IRequestHandler<GetCountriesServicePhonesQuerieRequest, List<GetCountryServicePhonesDTO>>
    {
        private readonly ICountryRepository CountryRepository;
        private readonly IServicePhoneRepository ServicePhoneRepository;

        public GetCountriesServicePhonesQuerieHandler(ICountryRepository CountryRepository, IServicePhoneRepository ServicePhoneRepository)
        {
            this.CountryRepository = CountryRepository;
            this.ServicePhoneRepository = ServicePhoneRepository;
        }

        public async Task<List<GetCountryServicePhonesDTO>> Handle(GetCountriesServicePhonesQuerieRequest request, CancellationToken cancellationToken)
        {
            var Countries = await CountryRepository.GetAllCountries();
            List<GetCountryServicePhonesDTO> Result = new List<GetCountryServicePhonesDTO>();
            foreach(var Country in Countries)
            {
                var ServiceTemp = await ServicePhoneRepository.GetServicePhone(Country.ServicePhoneId);
                GetCountryServicePhonesDTO temp = new GetCountryServicePhonesDTO
                {
                    Name = Country.Name,
                    Number = new GetServicePhoneDTO { Number = ServiceTemp.Number}
                };
                Result.Add(temp);
            }
            return Result;
        }
    }


}
