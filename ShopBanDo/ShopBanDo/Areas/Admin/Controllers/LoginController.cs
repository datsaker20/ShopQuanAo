using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopBanDo.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.DTO.UserModel user)
        {
                if (ModelState.IsValid)
            {
                bool isVal = Models.DAO.AccountDAO.checkLogin(user.username, user.password);
                if(isVal==true)
                {
                    Session["username"] = user.username;
                    return RedirectToAction("Index", "Home");
                   
                }
                else
                {
                    
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {

            //Session.Remove("username");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}