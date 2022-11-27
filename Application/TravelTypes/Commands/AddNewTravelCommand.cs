using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.ContryTypes.Contracts;
using Application.ExpenseTypes.Contracts;
using Application.OweSinglePaymentTypes.Contracts;
using Application.SpotTypes.Contracts;
using Application.TravelTypes.Contracts;
using Application.VisitDateTypes.Contracts;
using Azure;
using Domain.Common.DTO;
using Domain.Expense.Entities;
using Domain.OweSinglePayment.Entities;
using Domain.Spot.Entities;
using Domain.Travels.DTO;
using Domain.Travels.Validations;
using Domain.User.Validations;
using Domain.VisitDate.Entities;
using MediatR;

namespace Application.TravelTypes.Commands
{
    public class AddNewTravelCommandRequest : IRequest<BaseCommandResponse>
    {
        public AddNewTravelDTO Request { get; set; }
        public int UserId { get; set; }
    }

    public class AddNewTravelCommandHandler : IRequestHandler<AddNewTravelCommandRequest, BaseCommandResponse>
    {
        private readonly ITravelRepository TravelRepository;
        private readonly IVisitDatesRepository VisitDateRepository;
        private readonly ICountryRepository CountryRepository;
        private readonly IExpenseReposiotry ExpenseRepository;
        private readonly ISpotRepository SpotRepository;
        private readonly IOweSinglePaymentRepository SinglePaymentRepository;

        public AddNewTravelCommandHandler(ITravelRepository TravelRepository, ICountryRepository CountryRepository, IVisitDatesRepository VisitDateRepository, IExpenseReposiotry ExpenseRepository, ISpotRepository SpotRepository, IOweSinglePaymentRepository SinglePaymentRepository)
        {
            this.TravelRepository = TravelRepository;
            this.CountryRepository = CountryRepository;
            this.VisitDateRepository = VisitDateRepository;
            this.ExpenseRepository = ExpenseRepository;
            this.SpotRepository = SpotRepository;
            this.SinglePaymentRepository = SinglePaymentRepository;
        }

        public async Task<BaseCommandResponse> Handle(AddNewTravelCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new AddNewTravelDTOValidator();
            var response = new BaseCommandResponse();
            var validatorResult = await validator.ValidateAsync(request.Request);
            if (!validatorResult.IsValid)
            {
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
                response.Success = false;
                response.Message = "Something went wrong. Check validation message";
                response.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                Travel Travel = new Travel
                {
                    Name = request.Request.Name,
                    Destination = request.Request.Destination,
                    StartDate = request.Request.StartDate,
                    EndDate = request.Request.EndDate,
                    Note = null,
                    PlannedBudget = request.Request.PlannedBudget,
                    CreatedDate = DateTime.Now,
                    UserId = request.UserId,
                    CountryId = CountryRepository.GetCountryNames(request.Request.Country).Result.First().CountryId,
                    HotelName = request.Request.HotelName,
                    PickedCurrency = request.Request.Currency,
                    HotelStreet = request.Request.HotelStreet,
                    HotelBuildingNo = request.Request.HotelBuildingNo,
                    HotelFlatNo = request.Request.HotelFlatNo,
                    HotelCity = request.Request.HotelCity
                };

                int TravelId = await TravelRepository.AddNewTravel(Travel);

                foreach(var visitDate in request.Request.VisitDate)
                {
                    VisitDate insertVisitDate = new VisitDate
                    {
                        Date = visitDate.Date,
                        Title = visitDate.Title,
                        TravelId = TravelId
                    };
                    int VisitDateId = 0;
                    try {
                        VisitDateId = await VisitDateRepository.AddNewVisitDate(insertVisitDate);
                    }
                    catch (Exception)
                    {
                        response.Success = false;
                        response.Message = "VisitDate insert error";
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        return response;
                    }

                    if(visitDate.Spot != null && visitDate.Spot.Count > 0)
                    {
                        foreach (var Spot in visitDate.Spot)
                        {
                            var ExpenseId = 0;
                            if (Spot.Expense != null)
                            {
                                Expense insertExpense = new Expense
                                {
                                    Cost = Spot.Expense.Cost
                                };
                                try
                                {
                                    ExpenseId = await ExpenseRepository.AddExpense(insertExpense);
                                }catch(Exception)
                                {
                                    response.Success = false;
                                    response.Message = "Expense insert error";
                                    response.StatusCode = HttpStatusCode.InternalServerError;
                                    return response;
                                }

                                if (Spot.Expense.OweSinglePayment != null)
                                {
                                    foreach (var singlePayment in Spot.Expense.OweSinglePayment)
                                    {
                                        OweSinglePayment insertSinglePayment = new OweSinglePayment
                                        {
                                            PersonName = singlePayment.PersonName,
                                            PaymentAmount = singlePayment.PaymentAmount,
                                            PaymentStatus = singlePayment.PaymentStatus,
                                            PaymentDate = singlePayment.PaymentDate,
                                            IsPayer = singlePayment.IsPayer,
                                            ExpenseId = ExpenseId
                                        };
                                        int OweSinglePaymentId = 0;
                                        try
                                        {
                                            OweSinglePaymentId = await SinglePaymentRepository.AddNewOweSinglePayment(insertSinglePayment);
                                        }catch(Exception)
                                        {
                                            response.Success = false;
                                            response.Message = "OweSinglePayment insert error";
                                            response.StatusCode = HttpStatusCode.InternalServerError;
                                            return response;
                                        }
                                    }
                                }
                            }


                            Spot insertSpot = new Spot
                            {
                                Note = Spot.Note,
                                Order = Spot.Order,
                                Street = Spot.Street,
                                BuildingNo = Spot.BuildingNo,
                                FlatNo = Spot.FlatNo,
                                ZipCode = Spot.ZipCode,
                                VisitDateId = VisitDateId,
                                ExpenseId = ExpenseId,
                                CoordinateX = Spot.CoordinateX,
                                CoordinateY = Spot.CoordinateY,
                                Name = Spot.Name
                            };

                            int SpotId = 0;
                            try
                            {
                                SpotId = await SpotRepository.AddNewSpot(insertSpot);
                            }catch(Exception)
                            {
                                response.Success = false;
                                response.Message = "Spot insert error";
                                response.StatusCode = HttpStatusCode.InternalServerError;
                                return response;
                            }

                        }
                    }
                }
            }

            response.Success = true;
            response.Message = "Added";
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
