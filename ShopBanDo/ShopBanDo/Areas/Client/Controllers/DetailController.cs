using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanDo.Areas.Client.Controllers
{
    public class DetailController : Controller
    {
        Areas.Admin.Models.Framework.ShopQuanAoEntities db = new Areas.Admin.Models.Framework.ShopQuanAoEntities();
        // GET: Client/Detail
        public ActionResult Index(int id)
        {
            Areas.Admin.Models.Framework.SanPham ct = db.SanPham.First(x => x.id == id);
            ViewBag.ct = ct;

            return View();
        }
    }
}