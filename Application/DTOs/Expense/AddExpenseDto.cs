using Application.DTOs.OweSinglePayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Expense
{
    public class AddExpenseDto
    {
        public Decimal Cost { get; set; }
        public AddOweSinglePaymentDto[] SinglePayment { get; set; }
    }
}
