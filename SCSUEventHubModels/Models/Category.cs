using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SCSUEventHubModels.Models
{
    public class Category
    {
        public Category()
        {
            this.CategorySubscriptions = new HashSet<CategorySubscription>();
            this.Events = new HashSet<Event>();
        }

        public int ID { get; set; }
        public Nullable<int> AdminID { get; set; }
        public string CategoryName { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual ICollection<CategorySubscription> CategorySubscriptions { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
