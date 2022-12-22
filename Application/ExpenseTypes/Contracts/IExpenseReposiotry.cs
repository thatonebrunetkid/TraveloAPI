using Domain.Expense.Entities;
using Domain.VisitDate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExpenseTypes.Contracts
{
    public interface IExpenseReposiotry
    {
        Task <Expense> GetExpenseInfo(int ExpenseId);
        Task<int> AddExpense(Expense Expense);
        Task<bool> DeleteExpense(int ExpenseId);
        Task<int> UpdateExpense(Expense Expense);
    }
}
