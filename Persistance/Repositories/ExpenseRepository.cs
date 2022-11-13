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

        public async Task<List<Expense>> GetExpenseInfo(int ExpenseId)
        {
            return await DbContext.Expense.Where(e => e.ExpenseId == ExpenseId).ToListAsync();
        }
    }
}
