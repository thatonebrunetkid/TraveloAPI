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
    public class UpdateTravelCommandRequest : IRequest<BaseCommandResponse>
    {
        public AddNewTravelDTO Request { get; set; }
        public int UserId { get; set; }
        public int TravelId { get; set; }
    }

    public class UpdateTravelCommandHandler : IRequestHandler<UpdateTravelCommandRequest, BaseCommandResponse>
    {
        private readonly ITravelRepository TravelRepository;
        private readonly IVisitDatesRepository VisitDateRepository;
        private readonly ICountryRepository CountryRepository;
        private readonly IExpenseReposiotry ExpenseRepository;
        private readonly ISpotRepository SpotRepository;
        private readonly IOweSinglePaymentRepository SinglePaymentRepository;

        public UpdateTravelCommandHandler(ITravelRepository TravelRepository, ICountryRepository CountryRepository, IVisitDatesRepository VisitDateRepository, IExpenseReposiotry ExpenseRepository, ISpotRepository SpotRepository, IOweSinglePaymentRepository SinglePaymentRepository)
        {
            this.TravelRepository = TravelRepository;
            this.CountryRepository = CountryRepository;
            this.VisitDateRepository = VisitDateRepository;
            this.ExpenseRepository = ExpenseRepository;
            this.SpotRepository = SpotRepository;
            this.SinglePaymentRepository = SinglePaymentRepository;
        }

        public async Task<BaseCommandResponse> Handle(UpdateTravelCommandRequest request, CancellationToken cancellationToken)
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
                try
                {
                    var Travel = await TravelRepository.GetTravelInfo(request.TravelId);
                    Travel.Name = request.Request.Name;
                    Travel.Destination = request.Request.Destination;
                    Travel.StartDate = request.Request.StartDate;
                    Travel.EndDate = request.Request.EndDate;
                    Travel.PlannedBudget = request.Request.PlannedBudget;
                    Travel.CountryId = CountryRepository.GetCountryNames(request.Request.Country).Result.First().CountryId;
                    Travel.HotelName = request.Request.HotelName;
                    Travel.PickedCurrency = request.Request.Currency;
                    Travel.HotelStreet = request.Request.HotelStreet;
                    Travel.HotelBuildingNo = request.Request.HotelBuildingNo;
                    Travel.HotelFlatNo = request.Request.HotelFlatNo;
                    Travel.HotelCity = request.Request.HotelCity;

                    await TravelRepository.UpdateTravel(Travel);

                    var VisitDates = await VisitDateRepository.GetVisitDateInfoByTravel(request.TravelId);
                    if(request.Request.VisitDate.Count > 0)
                {
                    for (int j = 0; j < request.Request.VisitDate.Count; j++)
                    {
                        var VisitDateUpdate = VisitDates[j];
                        VisitDateUpdate.Date = request.Request.VisitDate[j].Date;
                        VisitDateUpdate.Title = request.Request.VisitDate[j].Title;

                        await VisitDateRepository.UpdateVisitDate(VisitDateUpdate);

                        var Spots = await SpotRepository.GetSpotInfoByVisitDate(VisitDateUpdate.VisitDateId);
                        if (request.Request.VisitDate[j].Spot.Count > 0)
                        {
                            for (int i = 0; i < request.Request.VisitDate[j].Spot.Count; i++)
                            {
                                var SpotUpdate = Spots[i];
                                SpotUpdate.Note = request.Request.VisitDate[j].Spot[i].Note;
                                SpotUpdate.Adress = request.Request.VisitDate[j].Spot[i].Adress;
                                SpotUpdate.CoordinateX = request.Request.VisitDate[j].Spot[i].CoordinateX;
                                SpotUpdate.CoordinateY = request.Request.VisitDate[j].Spot[i].CoordinateY;
                                SpotUpdate.Name = request.Request.VisitDate[j].Spot[i].Name;

                                await SpotRepository.UpdateSpot(SpotUpdate);

                                var ExpenseUpdate = await ExpenseRepository.GetExpenseInfo(SpotUpdate.ExpenseId);
                                ExpenseUpdate.Cost = request.Request.VisitDate[j].Spot[i].Expense.Cost;
                                await ExpenseRepository.UpdateExpense(ExpenseUpdate);

                                var OweSignlePayments = await SinglePaymentRepository.GetOweSinglePaymentsByExpense(ExpenseUpdate.ExpenseId);

                                if (request.Request.VisitDate[j].Spot[i].Expense.OweSinglePayment.Count > 0)
                                {
                                    for (int z = 0; z < request.Request.VisitDate[j].Spot[i].Expense.OweSinglePayment.Count; z++)
                                    {
                                        var OweSinglePaymentUdpate = OweSignlePayments[z];
                                        OweSinglePaymentUdpate.PersonName = request.Request.VisitDate[j].Spot[i].Expense.OweSinglePayment[z].PersonName;
                                        OweSinglePaymentUdpate.PaymentAmount = request.Request.VisitDate[j].Spot[i].Expense.OweSinglePayment[z].PaymentAmount;
                                        OweSinglePaymentUdpate.PaymentStatus = request.Request.VisitDate[j].Spot[i].Expense.OweSinglePayment[z].PaymentStatus;
                                        OweSinglePaymentUdpate.PaymentDate = request.Request.VisitDate[j].Spot[i].Expense.OweSinglePayment[z].PaymentDate;
                                        OweSinglePaymentUdpate.IsPayer = request.Request.VisitDate[j].Spot[i].Expense.OweSinglePayment[z].IsPayer;

                                        await SinglePaymentRepository.UpdateOweSinglePayment(OweSinglePaymentUdpate);
                                    }
                                }
                            }
                        }
                    }
                }

                    response = new BaseCommandResponse
                    {
                        Success = true,
                        Message = "Updated",
                        StatusCode = HttpStatusCode.OK
                    };

                }catch(Exception)
                {
                    response = new BaseCommandResponse
                    {
                        Success = false,
                        Message = "Failed",
                        StatusCode = HttpStatusCode.InternalServerError
                    };
                }
            }
            return response;
        }
    }
}
