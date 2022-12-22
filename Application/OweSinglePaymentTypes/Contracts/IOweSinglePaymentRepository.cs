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
        Task<int> AddNewOweSinglePayment(OweSinglePayment SinglePayment);
        Task<bool> DeleteOweSinglePayments(int ExpenseId);
        Task<int> UpdateOweSinglePayment(OweSinglePayment OweSinglePayment);
    }
}
