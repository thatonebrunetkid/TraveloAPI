using Application.Persistence.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TraveloDbContext _dbContext;

        public UserRepository(TraveloDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _dbContext.User
                 .FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        async Task<List<User>> IUserRepository.GetAll()
        {
            var users = await _dbContext.User.ToListAsync();
            return users;
        }
    }
}
