using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCSUEventHubClient.Models
{
    public class EventModel
    {
        public int ID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> AdminID { get; set; }
        public string EventName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
    }
}