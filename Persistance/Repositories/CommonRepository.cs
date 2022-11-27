using System;
using Application.Common;

namespace Persistance.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly TraveloDbContext DbContext;

        public CommonRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async void SaveAll()
        {
            await DbContext.SaveChangesAsync();
        }
    }

}

