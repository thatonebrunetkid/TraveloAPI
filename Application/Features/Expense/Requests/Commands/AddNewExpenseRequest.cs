using Application.DTOs.Expense;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expense.Requests
{
    public class AddNewExpenseRequest : IRequest<BaseCommandResponse>
    {
        public AddExpenseDto AddExpenseDto { get; set; }
    }
}
