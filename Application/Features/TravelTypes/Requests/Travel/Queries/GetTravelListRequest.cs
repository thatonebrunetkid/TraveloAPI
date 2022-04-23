using Application.DTOs.Travel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserTypes.Requests.Travel.Queries
{
    public class GetTravelListRequest : IRequest<List<AllTravelsDTO>>
    {
        public int UserId { get; set; }
    }
}
