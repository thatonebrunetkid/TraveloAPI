using Application.ExpenseTypes.Contracts;
using Domain.Expense.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class ExpenseRepository : IExpenseReposiotry
    {
        private readonly TraveloDbContext DbContext;

        public ExpenseRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<Expense> GetExpenseInfo(int ExpenseId)
        {
            return await DbContext.Expense.FirstAsync(x => x.ExpenseId == ExpenseId);
        }

        public async Task<int> AddExpense(Expense Expense)
        {
            await DbContext.Expense.AddAsync(Expense);
            await DbContext.SaveChangesAsync();
            return Expense.ExpenseId;
        }
    }
}
