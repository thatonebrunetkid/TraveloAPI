using Application.DTOs.Travel;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TravelTypes.Requests.Travel.Commands
{
    public class AddNewTravelRequest : IRequest<BaseCommandResponse>
    {
       public AddNewTravelDto AddNewTravelDto { get; set; }
    }
}
