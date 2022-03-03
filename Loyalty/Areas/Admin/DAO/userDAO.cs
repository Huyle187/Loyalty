using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public void Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        //Get Name of Image upto database
        public string GetFileName(HttpPostedFileBase imageFile)
        {
            var fileName = Path.GetFileName(imageFile.FileName);
            return fileName;
        }
    }
}