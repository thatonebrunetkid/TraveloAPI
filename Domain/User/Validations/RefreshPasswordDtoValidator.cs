using Domain.User.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Validations
{
    public class RefreshPasswordDtoValidator : AbstractValidator<RegreshPasswordExecuteDTO>
    {
        public RefreshPasswordDtoValidator()
        {
            RuleFor(p => p.Password)
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
