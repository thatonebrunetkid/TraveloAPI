using Application.DTOs.Alerts;
using Application.DTOs.Countries;
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
            CreateMap<Users, UserDTO>().ReverseMap();
            CreateMap<Users, UserNoIDDTO>().ReverseMap();
            #endregion Users
            #region Travels
            CreateMap<Travels, AllTravelsDTO>().ReverseMap();
            CreateMap<Travels, AddNewTravelDto>().ReverseMap();
            CreateMap<Travels, GetTravelDatesFromCurrentMonthDto>().ReverseMap();
            #endregion Travels
            #region Alerts
            CreateMap<Alerts, AlertDto>().ReverseMap();
            #endregion Alerts
            #region Countries
            CreateMap<Countries, GetCountryIdByNameDto>().ReverseMap();
            CreateMap<Countries, GetCountriesNamesRequestDto>().ReverseMap();
            #endregion Countries
            #region SystemNotifications
            CreateMap<SystemNotifications, SystemNotificationsDto>().ReverseMap();
            #endregion SystemNotifications
        }
    }
}
