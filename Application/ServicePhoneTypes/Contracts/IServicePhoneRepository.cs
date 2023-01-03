using Domain.Country.Entities;
using Domain.ServicePhone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServicePhoneTypes.Contracts
{
    public interface IServicePhoneRepository
    {
        Task<ServicePhone> GetServicePhone(int Id);
        Task<List<ServicePhone>> GetAll();
    }
}
