using Loyalty.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loyalty.Areas.Admin.DAO
{
    public class campaignDAO
    {
        private LoyaltyEntities db = new LoyaltyEntities();

        public IPagedList<Campaign> getList(int? size, int? page)
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

            var list = db.Campaigns
                    .ToList()
                    .OrderBy(m => m.campaignID)
                    .ToPagedList(pageNumber, pageSize);
            return list;
        }

        public IPagedList<Campaign> getListSearch(int? size, int? page, int campaignID)
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

            var list = db.Campaigns
                    .Where(p => p.campaignID == campaignID)
                    .ToList()
                    .OrderBy(m => m.campaignID)
                    .ToPagedList(pageNumber, pageSize);
            return list;
        }

        public IPagedList<Campaign> Search(int? size, int? page, string searchCampaignText)
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

            var list = db.Campaigns
                    .Where(p => p.campaignName.Contains(searchCampaignText) ||
                                p.typeCampagin.Contains(searchCampaignText) ||
                                p.Status.Contains(searchCampaignText))
                    .ToList()
                    .OrderBy(m => m.campaignID)
                    .ToPagedList(pageNumber, pageSize);
            return list;
        }
    }
}