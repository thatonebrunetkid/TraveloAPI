using Application.Persistence.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SystemNotificationsRepository : GenericRepository<SystemNotification>, ISystemNotificationsRepository
    {
        private readonly TraveloDbContext _DbContext;

        public SystemNotificationsRepository(TraveloDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<List<SystemNotification>> GetCurrentSystemNotifications()
        {
            var Notifications = await _DbContext.SystemNotification.Where(e => e.ValidDate >= DateTime.Now && e.CreatedDate <= DateTime.Now).ToListAsync();
            return Notifications;
        }
    }
}
