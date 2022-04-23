using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface ITravelsRepository : IGenericRepository<Travels>
    {
        Task<List<Travels>> GetAllTravelsAsync(int UserId);
        Task<Travels> GetTravelByIdAsync(int TravelId);
        
    }
}
