using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Loyalty.Models;
using PagedList;

namespace Loyalty.Areas.Admin.DAO
{
    public class userDAO
    {
        private LoyaltyEntities db = new LoyaltyEntities();

        public IPagedList<Product> getList(int? size, int? page)
        {
            // Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            // Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            // Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 2);

            // Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // Lấy tổng sồ record chia cho kích thước để biết bao nhiêu trang
            int total = (int)(db.Products.ToList().Count / pageSize) + 1;
            //Nếu số trang vượt quá tổng số trang thì gán là 1 hoặc bằng tổng số trang
            if (pageNumber > total)
                pageNumber = total;

            var list = db.Products
                    .ToList()
                    .OrderBy(m => m.productID)
                    .ToPagedList(pageNumber, pageSize);
            return list;
        }

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