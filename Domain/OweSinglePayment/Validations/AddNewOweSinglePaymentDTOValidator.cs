using System;
using Domain.OweSinglePayment.DTO;
using FluentValidation;

namespace Domain.OweSinglePayment.Validations
{
    public class AddNewOweSinglePaymentDTOValidator : AbstractValidator<AddNewOweSinglePaymentDTO>
    {
        public AddNewOweSinglePaymentDTOValidator()
        {
            RuleFor(p => p.PersonName)
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(p => p.PaymentAmount)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.PaymentStatus)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.PaymentDate)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(p => p.IsPayer)
                .NotNull().WithMessage("{PropertyName} cannot be null");
        }
    }
}

