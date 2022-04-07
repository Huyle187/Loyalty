using Loyalty.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loyalty.Areas.Admin.DAO
{
    public class CollectionDAO
    {
        private LoyaltyEntities db = new LoyaltyEntities();

        public IPagedList<Collection> getList(int? size, int? page)
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
            int total = (int)(db.Collections.ToList().Count / pageSize) + 1;
            //Nếu số trang vượt quá tổng số trang thì gán là 1 hoặc bằng tổng số trang
            if (pageNumber > total)
                pageNumber = total;

            var list = db.Collections
                    .ToList()
                    .OrderBy(m => m.campaignID)
                    .ToPagedList(pageNumber, pageSize);
            return list;
        }

        public IPagedList<Collection> getListSearch(int? size, int? page, int campaignID)
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
            int total = (int)(db.Collections.ToList().Count / pageSize) + 1;
            //Nếu số trang vượt quá tổng số trang thì gán là 1 hoặc bằng tổng số trang
            if (pageNumber > total)
                pageNumber = total;

            var list = db.Collections
                    .Where(p => p.campaignID == campaignID)
                    .ToList()
                    .OrderBy(m => m.campaignID)
                    .ToPagedList(pageNumber, pageSize);
            return list;
        }

        public IPagedList<Collection> Search(int? size, int? page, string searchCollectText)
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

            var list = db.Collections
                    .Where(p => p.collectionName.Contains(searchCollectText) ||
                                p.Campaign.campaignName.Contains(searchCollectText))
                    .ToList()
                    .OrderBy(m => m.collectionID)
                    .ToPagedList(pageNumber, pageSize);
            return list;
        }
    }
}