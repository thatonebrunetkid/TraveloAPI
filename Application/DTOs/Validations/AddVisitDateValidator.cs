using Application.DTOs.VisitDate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Validations
{
    public class AddVisitDateValidator : AbstractValidator<AddVisitDateDto>
    {
        public AddVisitDateValidator()
        {
            RuleFor(x => x.VisitDate)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .MaximumLength(30).WithMessage("{PropertyName} cannot be longer than 30 signs");
            RuleForEach(x => x.Spots).SetValidator(new AddNewSpotDtoValidator());
        }
    }
}
