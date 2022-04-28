using Application.DTOs.OweSinglePayment;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OweSignlePayment.Requests.Commands
{
    public class CreateSinglePaymentRequest : IRequest<BaseCommandResponse>
    {
        public AddOweSinglePaymentDto AddOweSinglePaymentDto { get; set; }
    }
}
