using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Models.Stores
{
    public class StoreCreateRequest
    {
        public string storeName { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Address { get; set; }
    }
}