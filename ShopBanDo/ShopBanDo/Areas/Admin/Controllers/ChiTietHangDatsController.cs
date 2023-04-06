using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopBanDo.Areas.Admin.Models.Framework;

namespace ShopBanDo.Areas.Admin.Controllers
{
    public class ChiTietHangDatsController : Controller
    {
        private ShopQuanAoEntities db = new ShopQuanAoEntities();

        // GET: Admin/ChiTietHangDats
        public ActionResult Index()
        {
            var chiTietHangDat = db.ChiTietHangDat.Include(c => c.SanPham).Include(c => c.DatHang);
            return View(chiTietHangDat.ToList());
        }

        // GET: Admin/ChiTietHangDats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHangDat chiTietHangDat = db.ChiTietHangDat.Find(id);
            if (chiTietHangDat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHangDat);
        }

        // GET: Admin/ChiTietHangDats/Create
        public ActionResult Create()
        {
            ViewBag.IdSanPham = new SelectList(db.SanPham, "id", "TenSanPham");
            ViewBag.idDatHang = new SelectList(db.DatHang, "id", "MoTaDatHang");
            return View();
        }

        // POST: Admin/ChiTietHangDats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idDatHang,IdSanPham,DonGia,SoLuongBan")] ChiTietHangDat chiTietHangDat)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHangDat.Add(chiTietHangDat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSanPham = new SelectList(db.SanPham, "id", "TenSanPham", chiTietHangDat.IdSanPham);
            ViewBag.idDatHang = new SelectList(db.DatHang, "id", "MoTaDatHang", chiTietHangDat.idDatHang);
            return View(chiTietHangDat);
        }

        // GET: Admin/ChiTietHangDats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHangDat chiTietHangDat = db.ChiTietHangDat.Find(id);
            if (chiTietHangDat == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSanPham = new SelectList(db.SanPham, "id", "TenSanPham", chiTietHangDat.IdSanPham);
            ViewBag.idDatHang = new SelectList(db.DatHang, "id", "MoTaDatHang", chiTietHangDat.idDatHang);
            return View(chiTietHangDat);
        }

        // POST: Admin/ChiTietHangDats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idDatHang,IdSanPham,DonGia,SoLuongBan")] ChiTietHangDat chiTietHangDat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHangDat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSanPham = new SelectList(db.SanPham, "id", "TenSanPham", chiTietHangDat.IdSanPham);
            ViewBag.idDatHang = new SelectList(db.DatHang, "id", "MoTaDatHang", chiTietHangDat.idDatHang);
            return View(chiTietHangDat);
        }

        // GET: Admin/ChiTietHangDats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHangDat chiTietHangDat = db.ChiTietHangDat.Find(id);
            if (chiTietHangDat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHangDat);
        }

        // POST: Admin/ChiTietHangDats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietHangDat chiTietHangDat = db.ChiTietHangDat.Find(id);
            db.ChiTietHangDat.Remove(chiTietHangDat);
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
