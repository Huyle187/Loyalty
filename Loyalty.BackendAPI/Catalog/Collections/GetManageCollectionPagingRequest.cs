using Loyalty.BackendAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Catalog.Collections
{
    public class GetManageCollectionPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
    }
}