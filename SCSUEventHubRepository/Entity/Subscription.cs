//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCSUEventHubRepository.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subscription
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
