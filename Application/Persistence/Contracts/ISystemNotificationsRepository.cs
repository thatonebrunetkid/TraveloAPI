using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface ISystemNotificationsRepository : IGenericRepository<SystemNotifications>
    {
        Task<List<SystemNotifications>> GetCurrentSystemNotifications();
    }
}
