using Loyalty.Areas.Admin.DAO;
using Loyalty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loyalty.Areas.Admin.Controllers
{
    public class CampaignController : Controller
    {
        private LoyaltyEntities db = new LoyaltyEntities();
        private campaignDAO _campaignDAO = new campaignDAO();
        private productDAO _productDAO = new productDAO();

        // GET: Admin/Campaign
        [HttpGet]
        public ActionResult Index(int? size, int? page)
        {
            ViewBag.CampaignID = new SelectList(db.Campaigns, "campaignID", "typeCampagin"); // List Campaign

            // 1.2. Tạo các biến ViewBag
            ViewBag.size = _productDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View(_campaignDAO.getList(size, page));
        }

        //Search dropdownList
        public ActionResult Filter(int? size, int? page, int campaignID = 0)
        {
            if (campaignID == 0)
            {
                return RedirectToAction("Index");
            }
            // Tìm kiếm theo Danh sách chủ đề
            ViewBag.CampaignID = new SelectList(db.Campaigns, "campaignID", "typeCampagin"); // List Campaign
            // Tạo các biến ViewBag
            ViewBag.size = _productDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View("Index", _campaignDAO.getListSearch(size, page, campaignID));
        }

        //Search text
        public ActionResult Search(int? size, int? page, string searchCampaignText)
        {
            //Check search Text
            if (searchCampaignText == "")
            {
                return RedirectToAction("Index");
            }
            // Tìm kiếm theo Danh sách chủ đề
            ViewBag.CampaignID = new SelectList(db.Campaigns, "campaignID", "typeCampagin"); // List Campaign

            // Tạo các biến ViewBag
            ViewBag.size = _productDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View("Index", _campaignDAO.Search(size, page, searchCampaignText));
        }

        //Add new Campaign
        [HttpGet]
        public ActionResult Create()
        {
            //var list = db.Collections.Where(c => c.collectionID == 1);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Campaign campaign)
        {
            var startdate = Request.Form["startdate"];
            var enddate = Request.Form["enddate"];

            //get data from Form
            campaign.startDate = DateTime.Parse(startdate);
            campaign.endDate = DateTime.Parse(enddate);

            if (ModelState.IsValid)
            {
                db.Campaigns.Add(campaign);
                db.SaveChanges();
                return RedirectToAction("Index", "Campaign");
            }
            return View(campaign);
        }

        //Delete Campaign
        public ActionResult Delete(int id)
        {
            var campaign = db.Campaigns.Find(id);
            if (campaign.Equals(null))
            {
                return RedirectToAction("Index");
            }

            db.Campaigns.Remove(campaign);
            db.SaveChanges();
            //TempData["XMessage"] = new MyMessage("Delete " + campaign.campaignName.ToUpper() + " is successfully!", "danger");
            return RedirectToAction("Index");
        }
    }
}