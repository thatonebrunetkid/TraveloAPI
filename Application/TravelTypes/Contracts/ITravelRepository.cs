using Domain.Travels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.TravelTypes.Contracts
{
    public interface ITravelRepository
    {
        Task<List<Travel>> GetAllTravels(int userId);
        Task<List<Travel>> GetTravelsForDashboardCalendar(int userId);
        Task<Travel> GetUpcomingTravel(int UserId);
        Task<Travel> GetTravelInfo(int TravelId);
        Task<int> AddNewTravel(Travel Travel);
        void DeleteParticularTravel(int TravelId);
        Task<int> UpdateTravel(Travel Travel);
        int GetUsedBudget(int TravelId);
    }
}
