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
    public class UserRequestRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly TraveloDbContext _dbContext;

        public UserRequestRepository(TraveloDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CheckEmail(string email)
        {
            return _dbContext.Users.Any(x => x.Email == email);
        }

        public async Task<Users> GetById(int id)
        {
           var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.UserId == id);
            return user;
        }

        public async Task<HttpStatusCode> RefreshPassword(string email, string password)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
                user.Password = password;
                user.PasswordDateUpdated = DateTime.Now;

                _dbContext.Update(user);
                return HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        async Task<List<Users>> IUserRepository.GetAll()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }
    }
}
