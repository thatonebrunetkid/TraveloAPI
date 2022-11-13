using Application.OweSinglePaymentTypes.Contracts;
using Domain.OweSinglePayment.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class OweSinglePaymentRepository : IOweSinglePaymentRepository
    {
        private readonly TraveloDbContext DbContext;

        public OweSinglePaymentRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<OweSinglePayment>> GetOweSinglePaymentsByExpense(int ExpenseId)
        {
            return await DbContext.OweSinglePayment.Where(e => e.ExpenseId == ExpenseId).ToListAsync();
        }
    }
}
