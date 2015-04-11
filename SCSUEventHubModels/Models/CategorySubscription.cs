using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubModels.Models
{
    public class CategorySubscription
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
    }
}
