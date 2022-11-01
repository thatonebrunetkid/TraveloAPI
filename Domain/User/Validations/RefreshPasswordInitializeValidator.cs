using Domain.User.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Validations
{
    public class RefreshPasswordInitializeValidator : AbstractValidator<RefreshPasswordInitializeDTO>
    {
        public RefreshPasswordInitializeValidator()
        {
            RuleFor(p => p.Email)
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .EmailAddress().WithMessage("Incorrect email adress");
        }
    }
}
