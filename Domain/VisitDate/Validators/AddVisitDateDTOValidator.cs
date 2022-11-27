using System;
using Domain.Spot.Validations;
using Domain.VisitDate.DTO;
using FluentValidation;

namespace Domain.VisitDate.Validators
{
    public class AddVisitDateDTOValidator : AbstractValidator<AddNewVisitDateDTO>
    {
       public AddVisitDateDTOValidator()
        {
            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleForEach(p => p.Spot)
                .SetValidator(new AddNewSpotDTOValidator());
        }
    }
}

