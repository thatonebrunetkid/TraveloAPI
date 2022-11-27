using System;
using Domain.Expense.Validations;
using Domain.Spot.DTO;
using FluentValidation;

namespace Domain.Spot.Validations
{
    public class AddNewSpotDTOValidator : AbstractValidator<AddNewSpotDTO>
    {
        public AddNewSpotDTOValidator()
        {

            RuleFor(p => p.CoordinateX)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannon be null");
            RuleFor(p => p.CoordinateY)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.Expense)
                .SetValidator(new AddNewExpenseDTOValidator());
        }
    }
}

