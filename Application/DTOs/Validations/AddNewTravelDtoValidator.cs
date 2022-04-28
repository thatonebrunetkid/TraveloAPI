using Application.DTOs.Travel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Validations
{
    public class AddNewTravelDtoValidator : AbstractValidator<AddNewTravelDto>
    {
        public AddNewTravelDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .MaximumLength(30).WithMessage("{PropertyName} cannot be longer than 30 signs");
            RuleFor(p => p.Destination)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .MaximumLength(255).WithMessage("{PropertyName} cannot be longer than 225 signs");
            RuleFor(p => p.StartDate)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.EndDate)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.ParticipatNumber)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.PlannedBudget)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.CountryId)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.UserId)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.Note)
                .MaximumLength(100).WithMessage("{PropertyName} cannot be longer than 100 signs");
            RuleFor(p => p.VisitDate).SetValidator(new AddVisitDateValidator());

        }
    }
}
