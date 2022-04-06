using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Common
{
    public class PageResult<T>
    {
        public List<T> Items { set; get; }
        public int TotalRecord { get; set; }
    }
}