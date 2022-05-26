﻿using Application.DTOs.Travel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TravelTypes.Requests.Travel.Queries
{
    public class GetTravelDatesFromCurrentMonthRequest : IRequest<List<GetTravelDatesFromCurrentMonthDto>>
    {
        public int UserId { get; set; }
    }
}