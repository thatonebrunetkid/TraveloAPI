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
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly TraveloDbContext _dbContext;

        public UserRepository(TraveloDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Users> GetById(int id)
        {
            var user = await _dbContext.Users
                 .FirstOrDefaultAsync(x => x.UserId == id);
            return user;
        }

        async Task<List<Users>> IUserRepository.GetAll()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }
    }
}
