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
        private userDAO _userDAO = new userDAO();

        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
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

        //Delete Product

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