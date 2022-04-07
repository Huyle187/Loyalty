using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Models.Entities
{
    public class Collection
    {
        public int collectionID { get; set; }
        public string collectionName { get; set; }
        public string typeCollection { get; set; }
        public Nullable<int> productID { get; set; }
        public Nullable<int> campaignID { get; set; }

        public Campaign Campaign { get; set; }
        public Product Product { get; set; }
    }
}