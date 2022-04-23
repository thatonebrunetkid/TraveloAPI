using Application.DTOs.Alerts;
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
            CreateMap<Users, AllSusersDto>().ReverseMap();
            #endregion Users
            #region Travels
            CreateMap<Travels, AllTravelsDTO>().ReverseMap();
            #endregion Travels
            #region Alerts
            CreateMap<Alerts, AlertDto>().ReverseMap();
            #endregion Alerts
        }
    }
}
