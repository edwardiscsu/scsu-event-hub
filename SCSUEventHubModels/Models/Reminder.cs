using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubModels.Models
{
    public class Reminder
    {
        public int ID { get; set; }
        public Nullable<int> SubscriptionID { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual Subscription Subscription { get; set; }
    }
}
