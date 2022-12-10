using Application.ContryTypes.Contracts;
using Application.ExpenseTypes.Contracts;
using Application.OweSinglePaymentTypes.Contracts;
using Application.SpotTypes.Contracts;
using Application.TravelTypes.Contracts;
using Application.VisitDateTypes.Contracts;
using AutoMapper;
using Domain.Expense.DTO;
using Domain.OweSinglePayment.DTO;
using Domain.Spot.DTO;
using Domain.Travels.DTO;
using Domain.VisitDate.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TravelTypes.Queries
{
    public class GetParticularTravelQuerieRequest : IRequest<AddNewTravelDTO>
    {
        public int TravelId { get; set; }
    }

    public class GetParticularTravelQuerieHandler : IRequestHandler<GetParticularTravelQuerieRequest, AddNewTravelDTO>
    {
        private readonly ITravelRepository TravelRepository;
        private readonly IVisitDatesRepository VisitDateRepository;
        private readonly ISpotRepository SpotRepository;
        private readonly IExpenseReposiotry ExpenseRepository;
        private readonly IOweSinglePaymentRepository OweSinglePaymentRepository;
        private readonly ICountryRepository CountryRepository;
        private readonly IMapper Mapper;

        public GetParticularTravelQuerieHandler(ITravelRepository TravelRepository, IVisitDatesRepository VisitDateRepository, ISpotRepository SpotRepository, IExpenseReposiotry ExpenseRepository, IOweSinglePaymentRepository OweSinglePaymentRepository, ICountryRepository CountryRepository, IMapper Mapper)
        {
            this.TravelRepository = TravelRepository;
            this.VisitDateRepository = VisitDateRepository;
            this.SpotRepository = SpotRepository;
            this.ExpenseRepository = ExpenseRepository;
            this.OweSinglePaymentRepository = OweSinglePaymentRepository;
            this.CountryRepository = CountryRepository;
            this.Mapper = Mapper;
        }

        public async Task<AddNewTravelDTO> Handle(GetParticularTravelQuerieRequest request, CancellationToken cancellationToken)
        {
            var Travel = await TravelRepository.GetTravelInfo(request.TravelId);
            var VisitDates = await VisitDateRepository.GetVisitDateInfoByTravel(request.TravelId);
            var ResultVisitDate = new List<AddNewVisitDateDTO>();

            foreach (var VisitDate in VisitDates)
            {
                var ParticularVisitDate = new AddNewVisitDateDTO();
                ParticularVisitDate.Date = VisitDate.Date;
                ParticularVisitDate.Title = VisitDate.Title;
                ParticularVisitDate.Spot = new List<AddNewSpotDTO>();
                var Spots = await SpotRepository.GetSpotInfoByVisitDate(VisitDate.VisitDateId);
                foreach (var Spot in Spots)
                {
                    var Expense = await ExpenseRepository.GetExpenseInfo(Spot.ExpenseId);
                    var SinglePayments = await OweSinglePaymentRepository.GetOweSinglePaymentsByExpense(Expense.ExpenseId);
                    var TempSpot = new AddNewSpotDTO
                    {
                        Order = Spot.Order,
                        Note = Spot.Note,
                        Adress = Spot.Adress,
                        CoordinateX = Spot.CoordinateX,
                        CoordinateY = Spot.CoordinateY,
                        Expense = new AddNewExpenseDTO
                        {
                            Cost = Expense.Cost,
                            OweSinglePayment = Mapper.Map<List<AddNewOweSinglePaymentDTO>>(SinglePayments)
                        }
                    };
                    ParticularVisitDate.Spot.Add(TempSpot);
                }
                ResultVisitDate.Add(ParticularVisitDate);
            }

            var Result = new AddNewTravelDTO
            {
                Name = Travel.Name,
                Destination = Travel.Destination,
                Country = CountryRepository.GetCountryInfo(Travel.CountryId).Result.Name,
                StartDate = Travel.StartDate,
                EndDate = Travel.EndDate,
                HotelName = Travel.HotelName,
                HotelStreet = Travel.HotelStreet,
                HotelBuildingNo = Travel.HotelBuildingNo,
                HotelFlatNo = Travel.HotelFlatNo,
                HotelZipCode = Travel.HotelZipCode,
                HotelCity = Travel.HotelCity,
                PlannedBudget = Travel.PlannedBudget,
                Currency = Travel.PickedCurrency,
                VisitDate = ResultVisitDate
            };

            return Result;
        }
    }
}
