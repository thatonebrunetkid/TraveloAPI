using Application.UserTypes.Contracts;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TraveloDbContext DbContext;

        public UserRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<User> AddNewUser(User user)
        {
            await DbContext.AddAsync(user);
            await DbContext.SaveChangesAsync();
            return user;
        }

        public async Task<HttpStatusCode> RefreshPasswordInitialize(string email, string password)
        {
            try
            {
                await DbContext.Database.ExecuteSqlRawAsync($"exec dbo.RecoveryPasswordChange '{email}', '{password}'");
                await DbContext.SaveChangesAsync();
                return HttpStatusCode.OK;
            }catch(Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public bool CheckEmail(string Email)
        {
            //zapytac o get awaiter na konsultacjach
            return DbContext.User.Any(e => e.Email == Email);
        }

        public async Task<HttpStatusCode> RefreshPassword(string Email, string Password)
        {
            try
            {
                await DbContext.Database.ExecuteSqlRawAsync($"exec dbo.RecoveryPasswordChange '{Email}', '{Password}'");
                await DbContext.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public Task<User> GetUserData(int UserId)
        {
            return DbContext.User.FirstAsync(e => e.UserId == UserId);
        }

        public async Task<HttpStatusCode> ChangePassword(int UserId, string Password)
        {
            var user = DbContext.User.First(e => e.UserId == UserId);
            if (user is not null)
            {
                user.Password = Password;
                await DbContext.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
            else
                return HttpStatusCode.InternalServerError;
        }

        public async Task<User> CheckIfUserExist(string Email, string Password)
        {
            return await DbContext.User.FirstOrDefaultAsync(e => e.Email == Email && e.Password == Password);
        }
    }
}
