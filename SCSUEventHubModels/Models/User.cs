using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubModels.Models
{
    public class User : Account
    {
        public User()
        {
            this.CategorySubscriptions = new HashSet<CategorySubscription>();
            this.Reccomendations = new HashSet<Recommendation>();
            this.Subscriptions = new HashSet<Subscription>();
        }

        public virtual ICollection<CategorySubscription> CategorySubscriptions { get; set; }
        public virtual ICollection<Recommendation> Reccomendations { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
