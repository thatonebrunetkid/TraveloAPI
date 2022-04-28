using Application.DTOs.Spot;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Spot.Requests.Commands
{
    public class AddSpotRequest : IRequest<BaseCommandResponse>
    {
        public AddSpotDto AddSpotDto { get; set; }
    }
}
