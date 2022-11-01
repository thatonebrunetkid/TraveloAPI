using Domain.User.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Validations
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .MaximumLength(30).WithMessage("{PropertyName} cannot be longer than 30 sings");
            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .MaximumLength(60).WithMessage("{PropertyName} cannot be longer than 60 signs");
            RuleFor(p => p.PhoneNumber)
                .MinimumLength(9).WithMessage("{PropertyName} is to short")
                .MaximumLength(14).WithMessage("{PropertyName} is too long");
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .MaximumLength(30).WithMessage("{PropertyName} too long")
                .EmailAddress().WithMessage("Invalid email adress");
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .MaximumLength(64).WithMessage("{PropertyName} too long");
        }
    }
}
