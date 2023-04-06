using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanDo.Areas.Admin.Models.Framework;

namespace ShopBanDo.Areas.Client.Controllers
{
    public class KhachHangController : Controller
    {
        ShopQuanAoEntities db = new ShopQuanAoEntities();
        // GET: Client/KhachHang
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KhachHang KH)
        {
            db.KhachHang.Add(KH);
            db.SaveChanges();
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
    }
}