using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopBanDo.Areas.Admin.Models.Framework;

namespace ShopBanDo.Areas.Admin.Controllers
{
    public class SanPhamsController : Controller
    {
        private ShopQuanAoEntities db = new ShopQuanAoEntities();

        // GET: Admin/SanPhams
        public ActionResult Index()
        {
            var sanPham = db.SanPham.Include(s => s.DanhMuc);
            return View(sanPham.ToList());
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            SanPham sp = new SanPham();
            ViewBag.idLoai = new SelectList(db.DanhMuc.OrderBy(x => x.id), "id", "TenLoai");
            return View(sp);
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idLoai,TenSanPham,GiaBan,GiaKhuyenMai,MoTa,ThongTinChiTiet,TenVietTat,SoLuong,HinhAnh")] SanPham sanPham)
        {

            try
            {
                var pro = sanPham.ImageUpload;
                if(pro!=null&&pro.ContentLength>0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.FileName);
                    string extension = Path.GetExtension(pro.FileName);
                    fileName = fileName + extension;
                    sanPham.HinhAnh = "~/Areas/UploadFile/" + fileName;
                    pro.SaveAs(Path.Combine(Server.MapPath("~/Areas/UploadFile/"), fileName));
                }
                db.SanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


            if (ModelState.IsValid)
            {
                int num = db.SanPham.Count(x => x.id == sanPham.id);
                if (num > 0)
                {
                    ModelState.AddModelError("id", "Id Đã tồn tại");
                }
                else
                {
                    db.SanPham.Add(sanPham);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.idLoai = new SelectList(db.DanhMuc, "id", "TenLoai", sanPham.idLoai);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLoai = new SelectList(db.DanhMuc, "id", "TenLoai", sanPham.idLoai);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idLoai,TenSanPham,GiaBan,GiaKhuyenMai,MoTa,ThongTinChiTiet,TenVietTat,SoLuong,HinhAnh")] SanPham sanPham)
        {

            try
            {
                var pro = sanPham.ImageUpload;
                if (pro != null && pro.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.FileName);
                    string extension = Path.GetExtension(pro.FileName);
                    fileName = fileName + extension;
                    sanPham.HinhAnh = "~/Areas/UploadFile/" + fileName;
                    pro.SaveAs(Path.Combine(Server.MapPath("~/Areas/UploadFile/"), fileName));
                }
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLoai = new SelectList(db.DanhMuc, "id", "TenLoai", sanPham.idLoai);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
