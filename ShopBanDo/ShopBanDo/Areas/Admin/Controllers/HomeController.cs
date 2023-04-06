using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanDo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
     
        public ActionResult Index()
        {
           if(Session["username"]==null || Session["username"].ToString()=="")
           {
                return RedirectToAction("Index", "Login");
           }    
            return View();
        }
    }
}