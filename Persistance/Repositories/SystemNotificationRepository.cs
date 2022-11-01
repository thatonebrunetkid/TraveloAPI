using Application.SystemNotificationsType.Contracts;
using Domain.SystemNotification.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class SystemNotificationRepository : ISystemNotificationRepository
    {
        private readonly TraveloDbContext DbContext;

        public SystemNotificationRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<SystemNotification>> GetAllSystemNotifications()
        {
            return await DbContext.SystemNotification.Where(e => e.ValidDate >= DateTime.Now && e.CreatedDate <= DateTime.Now).ToListAsync();
        }
    }
}
