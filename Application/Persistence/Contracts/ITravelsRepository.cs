using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface ITravelsRepository : IGenericRepository<Travel>
    {
        Task<List<Travel>> GetAllTravelsAsync(int UserId);
        Task<List<Travel>> GetTravelsForCurrentMonth(int userId);
        Task<Travel> GetCurrentTravel(int UserId);        
    }
}
