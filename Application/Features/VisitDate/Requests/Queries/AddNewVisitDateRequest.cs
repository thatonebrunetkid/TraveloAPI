using Application.DTOs.VisitDate;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VisitDate.Requests.Queries
{
    public class AddNewVisitDateRequest : IRequest<BaseCommandResponse>
    {
        public AddVisitDateDto AddVisitDateDto { get; set; }
    }
}
