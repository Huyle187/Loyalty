//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Loyalty.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Campaign
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Campaign()
        {
            this.Collections = new HashSet<Collection>();
        }
    
        public int campaignID { get; set; }
        public string campaignName { get; set; }
        public string Market { get; set; }
        public string typeCampagin { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public string Status { get; set; }
        public Nullable<int> productID { get; set; }
        public Nullable<int> storeID { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collection> Collections { get; set; }
    }
}
