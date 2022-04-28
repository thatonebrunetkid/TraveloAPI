using Application.DTOs.OweSinglePayment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Validations
{
    public class AddNewOweSinglePaymentValidator : AbstractValidator<AddOweSinglePaymentDto>
    {
        public AddNewOweSinglePaymentValidator()
        {
            RuleFor(x => x.PersonName)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(x => x.IsPayer)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(x => x.PaymentDate)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleFor(x => x.PaymentAmount)
                .NotNull().WithMessage("{PropertyName} cannot be null");
        }
    }
}
