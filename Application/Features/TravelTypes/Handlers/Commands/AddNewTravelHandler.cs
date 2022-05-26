using Application.DTOs.OweSinglePayment;
using Application.DTOs.Spot;
using Application.DTOs.Validations;
using Application.Features.TravelTypes.Requests.Travel.Commands;
using Application.Persistence.Contracts;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TravelTypes.Handlers.Commands
{
    public class AddNewTravelHandler : IRequestHandler<AddNewTravelRequest, BaseCommandResponse>
    {
        private readonly ITravelsRepository _TravelRepository;
        private readonly IVisitDateRepository _VisitDateRepository;
        private readonly ISpotRepository _SpotRepository;
        private readonly IExpenseRepository _ExpenseRepository;
        private readonly IOweSinglePaymentRepository _OweSinglePaymentRepository;
        private readonly ICountriesRepository _CountriesRepository;
        private readonly IMapper _Mapper;

        public AddNewTravelHandler(ITravelsRepository TravelRepository, IMapper Mapper, IVisitDateRepository VisitDateRepository, ISpotRepository SpotRepository, IExpenseRepository ExpenseRepository, IOweSinglePaymentRepository OweSignlePaymentRepository, ICountriesRepository countriesRepository)
        {
            _TravelRepository = TravelRepository;
            _VisitDateRepository = VisitDateRepository;
            _SpotRepository = SpotRepository;
            _ExpenseRepository = ExpenseRepository;
            _OweSinglePaymentRepository = OweSignlePaymentRepository;
            _CountriesRepository = countriesRepository;
            _Mapper = Mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddNewTravelRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new AddNewTravelDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.AddNewTravelDto);

            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var CountryId = _CountriesRepository.GetCountryIdByName(request.AddNewTravelDto.Destination);
            var Travel = _Mapper.Map<Travels>(new Travels()
            {
                Name = request.AddNewTravelDto.Name,
                Destination = request.AddNewTravelDto.Destination,
                StartDate = request.AddNewTravelDto.StartDate,
                EndDate = request.AddNewTravelDto.EndDate,
                IdFav = null,
                Note = request.AddNewTravelDto.Note,
                ParticipatNumber = request.AddNewTravelDto.ParticipatNumber,
                PlannedBudget = request.AddNewTravelDto.PlannedBudget,
                LinkUrl = null,
                LinkExpirationDate = null,
                CreatedDate = DateTime.Now,
                UserId = request.AddNewTravelDto.UserId,
                CountryId = CountryId.Result.CountryId
            });

            Travel = await _TravelRepository.Add(Travel);

            var VisitDate = _Mapper.Map<Domain.Entities.VisitDate>(new Domain.Entities.VisitDate()
            {
                TravelId = Travel.TravelId,
                Date = request.AddNewTravelDto.VisitDate.VisitDate,
                Title = request.AddNewTravelDto.VisitDate.Title
            });
            VisitDate = await _VisitDateRepository.Add(VisitDate);

            foreach(AddSpotDto item in request.AddNewTravelDto.VisitDate.Spots)
            {
                var Spot = _Mapper.Map<Domain.Entities.Spot>(new Domain.Entities.Spot()
                {
                    PlaceId = 0,
                    Note = item.Note,
                    Order = item.Order,
                    Street = item.Street,
                    BuildingNo = item.BuildingNo,
                    FlatNo = item.FlatNo,
                    ZipCode = item.ZipCode,
                    TravelDateId = VisitDate.TravelDateId
                });

                Spot = await _SpotRepository.Add(Spot);

                var Expense = _Mapper.Map<Domain.Entities.Expense>(new Domain.Entities.Expense()
                {
                    Cost = item.Expense.Cost,
                    SpotId = Spot.SpotId,
                    TravelId = Travel.TravelId
                });

                Expense = await _ExpenseRepository.Add(Expense);

                foreach(AddOweSinglePaymentDto payment in item.Expense.SinglePayment)
                {
                    var SinglePayment = _Mapper.Map<OweSinglePayment>(new OweSinglePayment()
                    {
                        PersonName = payment.PersonName,
                        PaymentAmount = payment.PaymentAmount,
                        PaymentStatus = payment.PaymentStatus,
                        PaymentDate = payment.PaymentDate,
                        ExpenseId = Expense.ExpenseId,
                        IsPayer = payment.IsPayer
                    });

                    SinglePayment = await _OweSinglePaymentRepository.Add(SinglePayment);
                }
            }


            response.Success = true;
            response.Message = "Creation Succeed";
            response.Id = Travel.TravelId;
            return response;
        }
    }
}
