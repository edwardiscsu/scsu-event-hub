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
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
