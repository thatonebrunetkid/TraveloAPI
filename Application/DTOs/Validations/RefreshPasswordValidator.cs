using Application.DTOs.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Validations
{
    public class RefreshPasswordValidator : AbstractValidator<RefreshPasswordCommandDto>
    {
        public RefreshPasswordValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .MaximumLength(30).WithMessage("{PropertyName} cannot be longer than 30 signs");
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .MaximumLength(64).WithMessage("{PropertyName} cannot be longer that 64 signs");
        }
    }
}
