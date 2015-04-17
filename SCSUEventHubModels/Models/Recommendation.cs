using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubModels.Models
{
    public class Recommendation
    {
        public int ID { get; set; }
        public Nullable<int> EventID { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
