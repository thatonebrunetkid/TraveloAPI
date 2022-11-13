using Application.ExpenseTypes.Contracts;
using Application.OweSinglePaymentTypes.Contracts;
using Application.SpotTypes.Contracts;
using Application.TravelTypes.Contracts;
using Application.VisitDateTypes.Contracts;
using AutoMapper;
using Domain.Expense.Entities;
using Domain.OweSinglePayment.DTO;
using Domain.OweSinglePayment.Entities;
using Domain.Spot.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TravelTypes.Queries
{
    public class GetPayersNameQuerieRequest : IRequest<List<GetOweSinglePayersDTO>>
    {
        public int TravelId { get; set; }
    }

    public class GetPayersNameQuerieHandler : IRequestHandler<GetPayersNameQuerieRequest, List<GetOweSinglePayersDTO>>
    {
        private readonly IVisitDatesRepository VisitDateRepository;
        private readonly ISpotRepository SpotRepository;
        private readonly IExpenseReposiotry ExpenseRepository;
        private readonly IOweSinglePaymentRepository OweSinglePaymentRepository;
        private readonly IMapper Mapper;

        public GetPayersNameQuerieHandler(IVisitDatesRepository VisitDateRepository, ISpotRepository SpotRepository, IExpenseReposiotry ExpenseRepository, IOweSinglePaymentRepository OweSinglePaymentRepository, IMapper Mapper)
        {
            this.VisitDateRepository = VisitDateRepository;
            this.SpotRepository = SpotRepository;
            this.ExpenseRepository = ExpenseRepository;
            this.OweSinglePaymentRepository = OweSinglePaymentRepository;
            this.Mapper = Mapper;
        }

        public async Task<List<GetOweSinglePayersDTO>> Handle(GetPayersNameQuerieRequest request, CancellationToken cancellationToken)
        {
            var VisitDates = await VisitDateRepository.GetVisitDateInfoByTravel(request.TravelId);
            List<Spot> Spots = new List<Spot>();
            foreach(var VisitDate in VisitDates)
            {
                var spotsTemp = await SpotRepository.GetSpotInfoByVisitDate(VisitDate.VisitDateId);
                foreach (var spot in spotsTemp)
                    Spots.Add(spot);
            }

            List<OweSinglePayment> Payments = new List<OweSinglePayment>();
          
            foreach(var spot in Spots)
            {
                var PaymentsTemp = await OweSinglePaymentRepository.GetOweSinglePaymentsByExpense(spot.ExpenseId);
                foreach (var payment in PaymentsTemp)
                    Payments.Add(payment);
            }

            return Mapper.Map<List<GetOweSinglePayersDTO>>(Payments.Distinct().ToList());
        }

    }
}
