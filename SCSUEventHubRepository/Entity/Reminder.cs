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
    
    public partial class Reminder
    {
        public int ID { get; set; }
        public Nullable<int> SubscriptionID { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Subscription Subscription { get; set; }
    }
}
