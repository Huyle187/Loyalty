using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loyalty.Models;

namespace Loyalty.Areas.Admin.DAO
{
    public class userDAO
    {
        private LoyaltyEntities db = new LoyaltyEntities();

        public Account getRow(string _userAccount)
        {
            var row = db.Accounts
                .Where(x => (x.email == _userAccount))
                .FirstOrDefault();
            return row;
        }
    }
}