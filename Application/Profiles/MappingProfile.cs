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
            CreateMap<Users, UserDTO>().ReverseMap();
            CreateMap<Users, UserNoIDDTO>().ReverseMap();
        }
    }
}
