using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Models.Entities
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string Unit { get; set; }
        public long netWeight { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Market { get; set; }
        public decimal Price { get; set; }
        public int oldStock { get; set; }
        public int newStock { get; set; }
        public DateTime importDate { get; set; }
        public string SKU { get; set; }
        public string imageBarcode { get; set; }
        public string linkBarcode { get; set; }
        public string image { get; set; }
        public string weight { get; set; }

        public ICollection<Campaign> Campaign { get; set; }
        public ICollection<Collection> Collection { get; set; }
        //public virtual ICollection<Customer> Customer { get; set; }
    }
}