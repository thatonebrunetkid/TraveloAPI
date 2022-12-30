using System;
using Domain.Expense.DTO;
using Domain.OweSinglePayment.Validations;
using FluentValidation;

namespace Domain.Expense.Validations
{
    public class AddNewExpenseDTOValidator : AbstractValidator<AddNewExpenseDTO>
    {
        public AddNewExpenseDTOValidator()
        {
            RuleFor(p => p.Cost)
                .NotNull().WithMessage("{PropertyName} cannot be null");
            RuleForEach(p => p.OweSinglePayment)
                .SetValidator(new AddNewOweSinglePaymentDTOValidator());
        }
    }
}

