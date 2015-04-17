using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubModels.Models
{
    public class Subscription
    {
        public Subscription()
        {
            this.Reminders = new HashSet<Reminder>();
        }

        public int ID { get; set; }
        public Nullable<int> EventID { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
        public virtual User User { get; set; }
    }
}
