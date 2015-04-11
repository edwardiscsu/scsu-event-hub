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
        public Category() { }

        [Key]
        public int CategoryId { get; set; }
        [Required] 
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        //public virtual ICollection<User> Users { get; set; }

        public CategorySubscription CategorySubscription { get; set; }
    }
}
