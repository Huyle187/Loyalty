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

        public List<Campaign> Campaigns { get; set; }
        public List<Collection> Collections { get; set; }
    }
}