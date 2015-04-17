using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubModels.Models
{
    public class Event
    {
        public Event()
        {
            this.Recommendations = new HashSet<Recommendation>();
            this.Subscriptions = new HashSet<Subscription>();
        }

        public int ID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> AdminID { get; set; }
        public string EventName { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Recommendation> Recommendations { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
