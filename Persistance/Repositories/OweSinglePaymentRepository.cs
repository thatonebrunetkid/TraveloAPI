﻿using Application.OweSinglePaymentTypes.Contracts;
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

        public async Task<int> AddNewOweSinglePayment(OweSinglePayment SinglePayment)
        {
            await DbContext.Database.ExecuteSqlRawAsync($"exec dbo.AddOweSinglePayment '{SinglePayment.PersonName}', '{SinglePayment.PaymentAmount}', '{SinglePayment.PaymentStatus}', '{SinglePayment.PaymentDate}', '{SinglePayment.IsPayer}', '{SinglePayment.ExpenseId}'");
            await DbContext.SaveChangesAsync();
            return SinglePayment.OweSinglePaymentId;
        }
    }
}
