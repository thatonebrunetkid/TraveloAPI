using Application.DTOs.Expense;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Validations
{
    public class AddExpenseValidator : AbstractValidator<AddExpenseDto>
    {
        public AddExpenseValidator()
        {
            RuleFor(e => e.Cost)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleForEach(e => e.SinglePayment).SetValidator(new AddNewOweSinglePaymentValidator());
        }
    }
}
