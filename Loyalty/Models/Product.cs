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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Campaigns = new HashSet<Campaign>();
            this.Collections = new HashSet<Collection>();
            this.Customers = new HashSet<Customer>();
            this.ProductImages = new HashSet<ProductImage>();
        }
    
        public int productID { get; set; }
        public string productName { get; set; }
        public string Unit { get; set; }
        public Nullable<long> netWeight { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Market { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> oldStock { get; set; }
        public Nullable<int> newStock { get; set; }
        public Nullable<System.DateTime> importDate { get; set; }
        public string SKU { get; set; }
        public string imageBarcode { get; set; }
        public string linkBarcode { get; set; }
        public string image { get; set; }
        public string weight { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Campaign> Campaigns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collection> Collections { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
