using Application.DTOs.Spot;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Validations
{
    public class AddNewSpotDtoValidator : AbstractValidator<AddSpotDto>
    {
        public AddNewSpotDtoValidator()
        {
            RuleFor(x => x.Note)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(x => x.Order)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(x => x.BuildingNo)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(x => x.FlatNo)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be empty");
            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(x => x.Expense).SetValidator(new AddExpenseValidator());
        }
    }
}
