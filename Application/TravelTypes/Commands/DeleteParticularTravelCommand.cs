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
        private readonly IVisitDatesRepository VisitDateRepository;
        private readonly ISpotRepository SpotRepository;
        private readonly IExpenseReposiotry ExpenseRepository;
        private readonly IOweSinglePaymentRepository OweSinglePaymentRepository;

        public DeleteParticularTravelCommandHandler(ITravelRepository Repository, IVisitDatesRepository VisitDateRepository, ISpotRepository SpotRepository, IExpenseReposiotry ExpenseRepository, IOweSinglePaymentRepository OweSinglePaymentRepository)
        {
            this.Repository = Repository;
            this.VisitDateRepository = VisitDateRepository;
            this.SpotRepository = SpotRepository;
            this.ExpenseRepository = ExpenseRepository;
            this.OweSinglePaymentRepository = OweSinglePaymentRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteParticularTravelCommandRequest request, CancellationToken cancellationToken)
        {
            if (await Repository.DeleteParticularTravel(request.TravelId))
            {
                var VisitDates = await VisitDateRepository.GetVisitDateInfoByTravel(request.TravelId);
                var Spots = new List<Spot>();
                foreach (var VisitDate in VisitDates)
                {
                    Spots.Concat(await SpotRepository.GetSpotInfoByVisitDate(VisitDate.VisitDateId));
                    await VisitDateRepository.DeleteVisitDates(VisitDate.VisitDateId);
                    await SpotRepository.DeleteSpot(VisitDate.VisitDateId);
                }

                var Payments = new List<OweSinglePayment>();
                foreach (var Spot in Spots)
                {
                    Payments.Concat(await OweSinglePaymentRepository.GetOweSinglePaymentsByExpense(Spot.ExpenseId));
                    await ExpenseRepository.DeleteExpense(Spot.ExpenseId);
                    await OweSinglePaymentRepository.DeleteOweSinglePayments(Spot.ExpenseId);
                }

                return new BaseCommandResponse
                {
                    Success = true,
                    Message = "Deleted",
                    StatusCode = HttpStatusCode.OK
                };
            }
            else
            {
                return new BaseCommandResponse
                {
                    Success = false,
                    Message = "Internal Server Error",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
