using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubModels.Models
{
    public class Event
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int AdminID { get; set; }

        public string EventName { get; set; }

        public DateTime EventDateTime { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }

        public Subscription Subscription { get; set; }
    }
}
