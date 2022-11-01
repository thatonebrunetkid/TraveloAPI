using Application.Flag.Contracts;
using Domain.Flag.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class FlagRepository : IFlagRepository
    {
        private readonly TraveloDbContext DbContext;

        public FlagRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<string> GetFlag(int FlagId)
        {
            var result = await DbContext.Flag.FirstAsync(e => e.FlagId == FlagId);
            return result.URL;
        }
    }
}
