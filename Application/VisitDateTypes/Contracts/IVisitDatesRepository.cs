using Domain.VisitDate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VisitDateTypes.Contracts
{
    public interface IVisitDatesRepository
    {
        Task<List<VisitDate>> GetVisitDateInfoByTravel(int TravelId);
        Task<int> AddNewVisitDate(VisitDate VisitDate);
        Task<int> UpdateVisitDate(VisitDate visitDate);
    }
}
