using Application.ExpenseTypes.Contracts;
using Application.OweSinglePaymentTypes.Contracts;
using Application.SpotTypes.Contracts;
using Application.TravelTypes.Contracts;
using Application.VisitDateTypes.Contracts;
using Domain.Common.DTO;
using Domain.Expense.Entities;
using Domain.OweSinglePayment.Entities;
using Domain.Spot.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TravelTypes.Commands
{
    public class DeleteParticularTravelCommandRequest : IRequest<BaseCommandResponse>
    {
        public int TravelId { get; set; }
    }

    public class DeleteParticularTravelCommandHandler : IRequestHandler<DeleteParticularTravelCommandRequest, BaseCommandResponse>
    {
        private readonly ITravelRepository Repository;

        public DeleteParticularTravelCommandHandler(ITravelRepository Repository)
        {
            this.Repository = Repository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteParticularTravelCommandRequest request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response;

            try
            {
                Repository.DeleteParticularTravel(request.TravelId);
                response = new BaseCommandResponse()
                {
                    Success = true,
                    Message = "Deleted",
                    StatusCode = HttpStatusCode.OK
                };
            }catch(Exception)
            {
                response = new BaseCommandResponse()
                {
                    Success = false,
                    Message = "Internal Server Error",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            return response;
        }
    }
}
