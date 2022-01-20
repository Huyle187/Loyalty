using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loyalty.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Admin/Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection filed)
        {
            string user = filed["email"];
            if (user != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(filed);
        }
    }
}