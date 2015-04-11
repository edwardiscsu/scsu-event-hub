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
        public int SubscriptionID { get; set; }

        public DateTime DateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
