using Domain.Expense.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExpenseTypes.Contracts
{
    public interface IExpenseReposiotry
    {
        Task<List<Expense>> GetExpenseInfo(int ExpenseId);
    }
}
