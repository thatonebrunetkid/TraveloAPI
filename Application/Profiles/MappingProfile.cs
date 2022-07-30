using Application.DTOs.Alerts;
using Application.DTOs.Countries;
using Application.DTOs.Dictionary;
using Application.DTOs.SystemNotofications;
using Application.DTOs.Travel;
using Application.DTOs.User;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Users
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserNoIDDTO>().ReverseMap();
            #endregion Users
            #region Travels
            CreateMap<Travel, AllTravelsDTO>().ReverseMap();
            CreateMap<Travel, AddNewTravelDto>().ReverseMap();
            CreateMap<Travel, GetTravelDatesFromCurrentMonthDto>().ReverseMap();
            #endregion Travels
            #region Alerts
            CreateMap<Alert, AlertDto>().ReverseMap();
            #endregion Alerts
            #region Countries
            CreateMap<Country, GetCountryNameByIdDto>().ReverseMap();
            CreateMap<Country, GetCountriesNamesRequestDto>().ReverseMap();
            CreateMap<Country, CountriesISOCodesDto>().ReverseMap();
            #endregion Countries
            #region SystemNotifications
            CreateMap<SystemNotification, GetSystemNotificationsDto>().ReverseMap();
            #endregion SystemNotifications
            #region Dictionary
            CreateMap<Dictionary, GetDictionaryDTO>().ReverseMap();
            CreateMap<DictionaryWord, GetDictionaryWordDTO>().ReverseMap();
            #endregion Dictionary
        }
    }
}
