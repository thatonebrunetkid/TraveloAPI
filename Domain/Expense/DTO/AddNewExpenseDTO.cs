using Domain.OweSinglePayment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Expense.DTO
{
    public class AddNewExpenseDTO
    {
        public Decimal Cost { get; set; }
        public List<AddNewOweSinglePaymentDTO>? OweSinglePayment { get; set; }
    }
}
