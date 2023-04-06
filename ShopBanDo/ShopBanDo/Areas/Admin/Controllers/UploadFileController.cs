using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanDo.Areas.Admin.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: Admin/UploadFile
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload()
        {
            var f = Request.Files["image"];
            if(f !=null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/Areas/FileUpload/") + f.FileName;
                f.SaveAs(path);
                ViewBag.FileName = f.FileName;
                ViewBag.FileType = f.ContentType;
                ViewBag.FileSize = f.ContentLength;
            }
            return View();
        }
    }
}