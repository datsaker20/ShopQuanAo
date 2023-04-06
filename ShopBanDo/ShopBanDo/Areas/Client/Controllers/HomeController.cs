using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanDo.Areas.Client.Controllers
{
    public class HomeController : Controller
    {
        Areas.Admin.Models.Framework.ShopQuanAoEntities db = new Areas.Admin.Models.Framework.ShopQuanAoEntities();
        // GET: Client/Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult DanhMucSanPham(int idLoai)
        {
            Areas.Admin.Models.Framework.DanhMuc ct = db.DanhMuc.First(x => x.id == idLoai);
            ViewBag.ct = ct;
    
            List<Areas.Admin.Models.Framework.SanPham> lst = db.SanPham.Where(x => x.idLoai == idLoai).Take(10).ToList();
            return PartialView(lst);
        }
    }
}