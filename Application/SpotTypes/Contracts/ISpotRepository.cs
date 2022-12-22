using Domain.Spot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SpotTypes.Contracts
{
    public interface ISpotRepository
    {
        Task<List<Spot>> GetSpotInfoByVisitDate(int VisitDateId);
        Task<int> AddNewSpot(Spot Spot);
        Task<bool> DeleteSpot(int VisitDateId);
        Task<int> UpdateSpot(Spot Spot);
    }
}
