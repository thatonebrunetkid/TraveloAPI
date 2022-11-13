using Domain.Alert.Entities;
using Domain.Country.Entities;
using Domain.Dictionary.Entities;
using Domain.DictionaryWord.Entities;
using Domain.Expense.Entities;
using Domain.Flag.DTO;
using Domain.OweSinglePayment.Entities;
using Domain.ServicePhone.Entity;
using Domain.Spot.Entities;
using Domain.SystemNotification.Entities;
using Domain.Travels.DTO;
using Domain.User;
using Domain.VisitDate.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance
{
    public class TraveloDbContext : DbContext
    {

        public TraveloDbContext(DbContextOptions<TraveloDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TraveloDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Alert> Alert { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Travel> Travel { get; set; }
        public DbSet<Dictionary> Dictionary { get; set; }
        public DbSet<DictionaryWord> DictionaryWord { get; set; }
        public DbSet<SystemNotification> SystemNotification { get; set; }
        public DbSet<Flag> Flag { get; set; }
        public DbSet<ServicePhone> ServicePhone { get; set; }
        public DbSet<VisitDate> VisitDate { get; set; }
        public DbSet<Spot> Spot { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<OweSinglePayment> OweSinglePayment { get; set; }
    }
}
