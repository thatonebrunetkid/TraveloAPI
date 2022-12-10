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

                int TravelId = 0;
                try
                {
                    TravelId = await TravelRepository.AddNewTravel(Travel);
                }
                catch (Exception)
                {
                    response.Success = false;
                    response.Message = "Something went wrong - Add Travel";
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    return response;
                }

                foreach (var VisitDate in request.Request.VisitDate)
                {
                    VisitDate VisitDateInput = new VisitDate
                    {
                        Date = VisitDate.Date,
                        Title = VisitDate.Title,
                        TravelId = TravelId
                    };

                    int VisitDateId = 0;

                    try
                    {
                        VisitDateId = await VisitDateRepository.AddNewVisitDate(VisitDateInput);
                    }catch(Exception)
                    {
                        response.Success = false;
                        response.Message = "Something went wrong - Add Visit Date";
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        return response;
                    }

                    if(VisitDate.Spot.Count > 0 && VisitDate.Spot != null)
                    {
                        foreach(var Spot in VisitDate.Spot)
                        {
                            int ExpenseId = 0;
                            if(Spot.Expense != null)
                            {
                                Expense ExpenseInput = new Expense
                                {
                                    Cost = Spot.Expense.Cost
                                };

                                try
                                {
                                    ExpenseId = await ExpenseRepository.AddExpense(ExpenseInput);
                                }catch(Exception)
                                {
                                    response.Success = false;
                                    response.Message = "Something Went Wrong - Expense input";
                                    response.StatusCode = HttpStatusCode.InternalServerError;
                                    return response;
                                }

                            }

                            int SpotId = 0;
                            Spot InputSpot = new Spot
                            {
                                Note = Spot.Note,
                                Order = Spot.Order,
                                Adress = Spot.Adress,
                                VisitDateId = VisitDateId,
                                ExpenseId = ExpenseId,
                                CoordinateX = Spot.CoordinateX,
                                CoordinateY = Spot.CoordinateY,
                                Name = Spot.Name
                            };

                            try
                            {
                                SpotId = await SpotRepository.AddNewSpot(InputSpot);
                            }catch(Exception)
                            {
                                response.Success = false;
                                response.Message = "Something went wrong - Add Spot";
                                response.StatusCode = HttpStatusCode.InternalServerError;
                                return response;
                            }

                            if(Spot.Expense.OweSinglePayment.Count > 0 && Spot.Expense.OweSinglePayment != null)
                            {
                                foreach(var OweSinglePayer in Spot.Expense.OweSinglePayment)
                                {
                                    OweSinglePayment InputSinglePayment = new OweSinglePayment
                                    {
                                        PersonName = OweSinglePayer.PersonName,
                                        PaymentAmount = OweSinglePayer.PaymentAmount,
                                        PaymentStatus = OweSinglePayer.PaymentStatus,
                                        PaymentDate = OweSinglePayer.PaymentDate,
                                        IsPayer = OweSinglePayer.IsPayer,
                                        ExpenseId = ExpenseId
                                    };

                                    try
                                    {
                                        await SinglePaymentRepository.AddNewOweSinglePayment(InputSinglePayment);
                                    }catch(Exception)
                                    {
                                        response.Success = false;
                                        response.Message = "Something went wrong - Add OweSinglePayment";
                                        response.StatusCode = HttpStatusCode.InternalServerError;
                                        return response;
                                    }
                                }
                            }
                        }
                    }
                }
                response.Success = true;
                response.Message = "Added";
                response.StatusCode = HttpStatusCode.OK;
                response.Id = TravelId;
            }
            return response;
        }
    }
}
