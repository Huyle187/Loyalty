using Loyalty.BackendAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Catalog.Stores
{
    public class GetManageStorePagingRequest : PagingRequestBase
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
    }
}