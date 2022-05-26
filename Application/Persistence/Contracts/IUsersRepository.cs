using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    //repozytorium dla danego entity
    public interface IUserRepository : IGenericRepository<Users>
    {
        public Task<Users> GetById(int id);
        public bool CheckEmail(string email);
        public Task<System.Net.HttpStatusCode> RefreshPassword(string email, string password);

    }
}
