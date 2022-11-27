using System;
using Domain.Travels.DTO;
using Domain.VisitDate.Validators;
using FluentValidation;

namespace Domain.Travels.Validations
{
    public class AddNewTravelDTOValidator : AbstractValidator<AddNewTravelDTO>
    {
        public AddNewTravelDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.Destination)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.Country)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.EndDate)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.PlannedBudget)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.Currency)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleForEach(p => p.VisitDate)
                .SetValidator(new AddVisitDateDTOValidator());
        }
    }
}

