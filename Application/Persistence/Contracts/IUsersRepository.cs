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
        public Task<List<Users>> GetAll();
        public Task<Users> GetById(int id);
    }
}
