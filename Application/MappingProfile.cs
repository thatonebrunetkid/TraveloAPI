using AutoMapper;
using Domain.Alert.DTO;
using Domain.Alert.Entities;
using Domain.Country.DTO;
using Domain.Country.Entities;
using Domain.Dictionary.DTO;
using Domain.Dictionary.Entities;
using Domain.DictionaryWord.DTO;
using Domain.DictionaryWord.Entities;
using Domain.OweSinglePayment.DTO;
using Domain.OweSinglePayment.Entities;
using Domain.SystemNotification.DTO;
using Domain.SystemNotification.Entities;
using Domain.Travels.DTO;
using Domain.User;
using Domain.User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<Alert, AllAlertsDTO>().ReverseMap();
            CreateMap<Country, CountryNameDTO>().ReverseMap();
            CreateMap<Travel, TravelDTO>().ReverseMap();
            CreateMap<Country, CountryISOCodeDTO>().ReverseMap();
            CreateMap<Domain.Dictionary.Entities.Dictionary, GetDictionaryDTO>().ReverseMap();
            CreateMap<DictionaryWord, GetDictionaryWordsDTO>().ReverseMap();
            CreateMap<SystemNotification, GetAllSystemNotificationsDTO>().ReverseMap();
            CreateMap<Travel, TravelDashboardCalendarDTO>().ReverseMap();
            CreateMap<Country, GetCurrencyListDTO>().ReverseMap();
            CreateMap<OweSinglePayment, GetOweSinglePayersDTO>().ReverseMap();
        }
    }
}
