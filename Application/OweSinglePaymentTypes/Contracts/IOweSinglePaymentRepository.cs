using Domain.OweSinglePayment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OweSinglePaymentTypes.Contracts
{
    public interface IOweSinglePaymentRepository
    {
        Task<List<OweSinglePayment>> GetOweSinglePaymentsByExpense(int ExpenseId);
    }
}
