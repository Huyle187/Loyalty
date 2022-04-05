using Loyalty.Areas.Admin.DAO;
using Loyalty.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loyalty.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private LoyaltyEntities db = new LoyaltyEntities();
        private productDAO _userDAO = new productDAO();

        // GET: Admin/Product
        [HttpGet]
        public ActionResult Index(int? size, int? page)
        {
            // Tìm kiếm theo Danh sách chủ đề
            ViewBag.ProductID = new SelectList(db.Products, "productID", "productName"); // List Product

            // Tạo các biến ViewBag
            ViewBag.size = _userDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View(_userDAO.getList(size, page));
        }

        public ActionResult Search(int? size, int? page, string searchProduct)
        {
            //Check search Text
            if (searchProduct == "")
            {
                return RedirectToAction("Index");
            }
            // Tìm kiếm theo Danh sách chủ đề
            ViewBag.ProductID = new SelectList(db.Products, "productID", "productName"); // List Product

            // Tạo các biến ViewBag
            ViewBag.size = _userDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View("Index", _userDAO.Search(size, page, searchProduct));
        }

        //Search dropdownList
        public ActionResult Filter(int? size, int? page, int productID = 0)
        {
            if (productID == 0)
            {
                return RedirectToAction("Index");
            }
            // Tìm kiếm theo Danh sách chủ đề
            ViewBag.ProductID = new SelectList(db.Products, "productID", "productName"); // List Product
            // Tạo các biến ViewBag
            ViewBag.size = _userDAO.getItem(size); // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            return View("Index", _userDAO.getListSearch(size, page, productID));
        }

        //Add new Product
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product _product, HttpPostedFileBase imageProduct)
        {
            var size = Request.Form["Size"];
            var weight = Request.Form["weight"];

            _product.weight = weight;
            _product.Size = size.ToString();
            _product.importDate = DateTime.Now;
            _product.SKU = "SKUPPBPC01VN";
            _product.image = _userDAO.GetFileName(imageProduct);

            if (ModelState.IsValid)
            {
                db.Products.Add(_product);
                db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            return View(_product);
        }

        //Update Product
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.productID == id);
            if (product == null)
            {
                //TempData["XMessage"] = new MyMessage("Not Fount the Product to Update!", "danger");
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase imageProduct)
        {
            if (imageProduct != null)
            {
                //Update new Image
                product.image = _userDAO.GetFileName(imageProduct);
            }
            if (product.image == null)
            {
                //TempData["CheckImage"] = new MyMessage("Vui lòng chọn hình ảnh", "danger");
                return View(product);
            }

            var size = Request.Form["Size"];
            var weight = Request.Form["weight"];

            product.weight = weight;
            product.Size = size.ToString();
            product.importDate = DateTime.Now;
            product.SKU = "SKUPPBPC01VN";

            if (ModelState.IsValid)
            {
                _userDAO.Update(product);
                //TempData["XMessage"] = new MyMessage("Update " + product.TenHang.ToUpper() + " is successfully!", "danger");
                return RedirectToAction("Index");
            }
            return View();
        }

        //Delete Product
        public ActionResult Delete(int id)
        {
            var _product = db.Products.Find(id);
            if (_product.Equals(null))
            {
                return RedirectToAction("Index");
            }

            db.Products.Remove(_product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Save and upload Image to Website
        [HttpPost]
        public JsonResult SaveFile(HttpPostedFileBase file)
        {
            string returnImagePath = string.Empty;
            if (file.ContentLength > 0)
            {
                string fileName, fileExtension, imaageSavePath;
                fileName = Path.GetFileNameWithoutExtension(file.FileName);
                fileExtension = Path.GetExtension(file.FileName);
                imaageSavePath = Server.MapPath("/Areas/Admin/Public/images/") + fileName + fileExtension;
                //Save file
                file.SaveAs(imaageSavePath);
                //Path to return
                returnImagePath = "/Areas/Admin/Public/images/" + fileName + fileExtension;
            }
            return Json(returnImagePath, JsonRequestBehavior.AllowGet);
        }
    }
}