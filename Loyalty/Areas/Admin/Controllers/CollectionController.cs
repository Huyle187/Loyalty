using Loyalty.Areas.Admin.DAO;
using Loyalty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loyalty.Areas.Admin.Controllers
{
    public class CollectionController : Controller
    {
        private LoyaltyEntities db = new LoyaltyEntities();
        private CollectionDAO _collectionDAO = new CollectionDAO();
        private productDAO _productDAO = new productDAO();

        // GET: Admin/Collection
        [HttpGet]
        public ActionResult Index(int? size, int? page)
        {
            ViewBag.CampaignID = new SelectList(db.Campaigns, "campaignID", "campaignName"); // List Campaign

            // 1.2. Tạo các biến ViewBag
            ViewBag.size = _productDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View(_collectionDAO.getList(size, page));
        }

        //Search dropdownList
        public ActionResult Filter(int? size, int? page, int campaignID = 0)
        {
            if (campaignID == 0)
            {
                return RedirectToAction("Index");
            }
            // Tìm kiếm theo Danh sách chủ đề
            ViewBag.CampaignID = new SelectList(db.Campaigns, "campaignID", "campaignName"); // List Campaign
            // Tạo các biến ViewBag
            ViewBag.size = _productDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View("Index", _collectionDAO.getListSearch(size, page, campaignID));
        }

        //Search text
        public ActionResult Search(int? size, int? page, string searchCollectText)
        {
            //Check search Text
            if (searchCollectText == "")
            {
                return RedirectToAction("Index");
            }
            // Tìm kiếm theo Danh sách chủ đề
            ViewBag.CampaignID = new SelectList(db.Campaigns, "campaignID", "campaignName"); // List Campaign

            // Tạo các biến ViewBag
            ViewBag.size = _productDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View("Index", _collectionDAO.Search(size, page, searchCollectText));
        }

        [HttpGet]
        public ActionResult Create()
        {
            //var list = db.Collections.Where(c => c.collectionID == 1);
            return View();
        }
    }
}