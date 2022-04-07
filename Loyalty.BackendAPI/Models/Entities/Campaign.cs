using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Models.Entities
{
    public class Campaign
    {
        public int campaignID { get; set; }
        public string campaignName { get; set; }
        public string Market { get; set; }
        public string typeCampagin { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public string Status { get; set; }
        public Nullable<int> productID { get; set; }
        public Nullable<int> collectionID { get; set; }
        public Nullable<int> storeID { get; set; }

        public List<Collection> Collections { get; set; }
        public List<Product> Products { get; set; }
    }
}