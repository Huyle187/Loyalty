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
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string Status { get; set; }
        public int productID { get; set; }
        public int storeID { get; set; }

        public Product Product { get; set; }

        public ICollection<Collection> Collection { get; set; }
    }
}