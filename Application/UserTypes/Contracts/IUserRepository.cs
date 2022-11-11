using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTypes.Contracts
{
    public interface IUserRepository
    {
        Task<User> AddNewUser(User user);
        Task<HttpStatusCode> RefreshPasswordInitialize(string email, string password);
        bool CheckEmail(string email);
        Task<HttpStatusCode> RefreshPassword(string Email, string Password);
    }
}
