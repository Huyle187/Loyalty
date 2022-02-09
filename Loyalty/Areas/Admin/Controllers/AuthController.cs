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
            ViewBag.StrError = "";
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection filed)
        {
            string error = "";
            string user = filed["email"];
            string password = filed["password"];
            if (user == "")
            {
                if (password == "")
                {
                    error = "Email và mật khẩu không được để trống!";
                }
                else
                {
                    error = "Email không được để trống!";
                }
            }
            else
            {
                if (password == "")
                {
                    error = "Mật khẩu không được để trống!";
                }
                else
                {
                    if (user == "admin@gmail.com")
                    {
                        if (password == "123456")
                        {
                            Session["UserAdmin"] = "admin@gmail.com";
                            return RedirectToAction("Index", "Dashboard");
                        }
                        else
                        {
                            error = "Mật khẩu không chính xác!";
                        }
                    }
                    else
                    {
                        if (password != "123456")
                        {
                            error = "Email và mật khẩu không chính xác!";
                        }
                        else
                        {
                            error = "Email không chính xác!";
                        }
                    }
                }
            }
            ViewBag.StrError = "<div class = 'text-danger'>* " + error + "</div>";
            return View();
        }

        // Admin/Auth/Forgot_password
        public ActionResult Forgot_password()
        {
            ViewBag.StrError = "";
            return View();
        }

        [HttpPost]
        public ActionResult Forgot_password(FormCollection filed)
        {
            return View();
        }
    }
}