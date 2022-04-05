using Loyalty.Areas.Admin.DAO;
using Loyalty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loyalty.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        private LoyaltyEntities db = new LoyaltyEntities();
        private productDAO userDAO = new productDAO();

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

            Account acc = userDAO.getRow(user);
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
                    if (acc != null)
                    {
                        if (acc.password.Equals(password))
                        {
                            if (acc.enable == 1)
                            {
                                Session["UserAdmin"] = acc.email;
                                return RedirectToAction("Index", "Dashboard");
                            }
                            else
                            {
                                error = "Tài khoản của bạn đang bị khóa!";
                            }
                        }
                        else
                        {
                            error = "Mật khẩu không chính xác!";
                        }
                    }
                    else
                    {
                        if (!acc.password.Equals(password))
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

        public ActionResult Logout()
        {
            Session["UserAdmin"] = "";
            return RedirectToAction("Login", "Auth");
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