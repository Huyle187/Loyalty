using Loyalty.Areas.Admin.DAO;
using Loyalty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loyalty.Areas.Admin.Controllers
{
    public class InventoryController : Controller
    {
        private LoyaltyEntities db = new LoyaltyEntities();
        private inventoryDAO _inventoryDAO = new inventoryDAO();
        private productDAO _productDAO = new productDAO();

        // GET: Admin/Inventory
        [HttpGet]
        public ActionResult Index(int? size, int? page)
        {
            // Tạo các biến ViewBag
            ViewBag.size = _productDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View(_productDAO.getList(size, page));
        }

        public ActionResult Search(int? size, int? page, string searchInventoryText, string searchInvenStoreText)
        {
            //  Tạo các biến ViewBag
            ViewBag.size = _productDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            if (searchInventoryText == "" && String.IsNullOrEmpty(searchInvenStoreText))
            {
                return RedirectToAction("Index");
            }
            if (searchInvenStoreText == "" && String.IsNullOrEmpty(searchInventoryText))
            {
                return RedirectToAction("Store");
            }

            if (searchInvenStoreText != "" && String.IsNullOrEmpty(searchInventoryText))
            {
                return View("Store", _productDAO.Search(size, page, searchInvenStoreText));
            }

            return View("Index", _productDAO.Search(size, page, searchInventoryText));
        }

        // GET: Admin/Store's Inventory
        [HttpGet]
        public ActionResult Store(int? size, int? page)
        {
            // Tạo các biến ViewBag
            ViewBag.size = _productDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View(_productDAO.getList(size, page));
        }

        //Update Inventory
        public ActionResult Update(int? size, int? page)
        {
            // Tạo các biến ViewBag
            ViewBag.size = _productDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View(_productDAO.getList(size, page));
        }
    }
}