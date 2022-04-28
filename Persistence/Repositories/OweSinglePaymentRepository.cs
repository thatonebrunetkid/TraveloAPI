using Application.Persistence.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OweSinglePaymentRepository : GenericRepository<OweSinglePayment>, IOweSinglePaymentRepository
    {
        private readonly TraveloDbContext _dbContext;

        public OweSinglePaymentRepository(TraveloDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
