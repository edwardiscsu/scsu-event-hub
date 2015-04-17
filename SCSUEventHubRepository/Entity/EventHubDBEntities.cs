
using Microsoft.AspNet.Identity.EntityFramework;
using SCSUEventHubModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubRepository.Entity
{
    public class EventHubDBEntities : IdentityDbContext<Account>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<CategorySubscription> CategorySubscriptions { get; set; }
        public DbSet<User> ClientUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public EventHubDBEntities()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static EventHubDBEntities Create()
        {
            return new EventHubDBEntities();
        }
    }
}