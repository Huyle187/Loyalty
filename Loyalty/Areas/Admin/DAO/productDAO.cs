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
    public class productDAO
    {
        private LoyaltyEntities db = new LoyaltyEntities();

        public List<SelectListItem> getItem(int? size)
        {
            //Tạo giá trị số lượng sản phẩm muốn hiển thị lên trang
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "15", Value = "15" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "25", Value = "25" });
            items.Add(new SelectListItem { Text = "30", Value = "30" });
            // 1.1. Giữ trạng thái kích thước trang được chọn trên DropDownList
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }

            return items;
        }

        public IPagedList<Product> getList(int? size, int? page)
        {
            // Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            // Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            // Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 5);

            // Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // Lấy tổng sồ record chia cho kích thước để biết bao nhiêu trang
            int total = (int)(db.Products.ToList().Count / pageSize) + 1;
            //Nếu số trang vượt quá tổng số trang thì gán là 1 hoặc bằng tổng số trang
            if (pageNumber > total)
                pageNumber = total;

            //.Where(p => p.productName.Contains(searchProduct) ||
            //    p.SKU.Contains(searchProduct) ||
            //    p.oldStock.ToString() == searchProduct)
            var list = db.Products
                    .ToList()
                    .OrderBy(m => m.productID)
                    .ToPagedList(pageNumber, pageSize);
            return list;
        }

        public IPagedList<Product> getListSearch(int? size, int? page, int productID)
        {
            // Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            // Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            // Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 5);

            // Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // Lấy tổng sồ record chia cho kích thước để biết bao nhiêu trang
            int total = (int)(db.Products.ToList().Count / pageSize) + 1;
            //Nếu số trang vượt quá tổng số trang thì gán là 1 hoặc bằng tổng số trang
            if (pageNumber > total)
                pageNumber = total;

            var list = db.Products
                    .Where(p => p.productID == productID)
                    .ToList()
                    .OrderBy(m => m.productID)
                    .ToPagedList(pageNumber, pageSize);
            return list;
        }

        public IPagedList<Product> Search(int? size, int? page, string searchProduct)
        {
            // Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            // Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            // Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 5);

            // Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // Lấy tổng sồ record chia cho kích thước để biết bao nhiêu trang
            int total = (int)(db.Products.ToList().Count / pageSize) + 1;
            //Nếu số trang vượt quá tổng số trang thì gán là 1 hoặc bằng tổng số trang
            if (pageNumber > total)
                pageNumber = total;

            var list = db.Products
                    .Where(p => p.productName.Contains(searchProduct) ||
                                p.SKU.Contains(searchProduct) ||
                                p.oldStock.ToString() == searchProduct)
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

        public void Update(Product product)
        {
            var _product = db.Products.Find(product.productID);

            _product.productName = product.productName;
            _product.Description = product.Description;
            _product.Market = product.Market;
            _product.weight = product.weight;
            _product.Size = product.Size;
            _product.Price = product.Price;
            _product.SKU = product.SKU;
            _product.Unit = product.Unit;
            _product.importDate = product.importDate;
            _product.netWeight = product.netWeight;
            _product.oldStock = product.oldStock;
            _product.newStock = product.newStock;
            _product.linkBarcode = product.linkBarcode;
            _product.imageBarcode = product.imageBarcode;
            _product.image = product.image;

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