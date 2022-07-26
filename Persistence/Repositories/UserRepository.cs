using Application.Persistence.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public bool CheckEmail(string email)
        {
            return _dbContext.User.Any(x => x.Email == email);
        }

        public async Task<User> GetById(int id)
        {
            var user = await _dbContext.User
                 .FirstOrDefaultAsync(x => x.UserId == id);
            return user;
        }

        public async Task<System.Net.HttpStatusCode> RefreshPassword(string email, string password)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync($"exec dbo.RecoveryPasswordChange '{email}', '{password}'");
                await _dbContext.SaveChangesAsync();
                return HttpStatusCode.OK;
            }catch(Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

    }
}
