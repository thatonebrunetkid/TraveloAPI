using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    //repozytorium dla danego entity
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<List<User>> GetAll();
        public Task<User> GetById(int id);
    }
}
