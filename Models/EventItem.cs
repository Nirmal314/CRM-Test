//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventItem
    {
        public int EventItemId { get; set; }
        public Nullable<int> EventId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> IsDeleted { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual Product Product { get; set; }
    }
}