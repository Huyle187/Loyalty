using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Models.Collections
{
    public class CollectionViewModel
    {
        private int total;
        public int collectionID { get; set; }
        public string collectionName { get; set; }
        public string typeCollection { get; set; }
        public int? productID { get; set; }
        public int? stock { get; set; }

        public int totalProduct
        {
            get { return total; }
            set { total = value; }
        }

        public int? campaignID { get; set; }
        public string campaignName { get; set; }
    }
}