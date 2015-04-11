using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubModels.Models
{
    public class Subscription
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }

        public ICollection<Reminder> Reminders { get; set; }
    }
}
