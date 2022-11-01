using Domain.SystemNotification.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SystemNotificationsType.Contracts
{
    public interface ISystemNotificationRepository
    {
        Task<List<SystemNotification>> GetAllSystemNotifications();
    }
}
