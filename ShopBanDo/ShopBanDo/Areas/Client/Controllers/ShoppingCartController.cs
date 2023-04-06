using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanDo.Areas.Admin.Models.Framework;
using ShopBanDo.Areas.Client.Models;

namespace ShopBanDo.Areas.Client.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShopQuanAoEntities db = new ShopQuanAoEntities();
        // GET: Client/ShoppingCart
        public Cart GetCart()
        {
            Cart cart= Session["Cart"] as Cart; 
            if (cart==null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart(int id)
        {
            var sp = db.SanPham.SingleOrDefault(x => x.id == id);
            if (sp != null)
            {
                GetCart().Add(sp);

            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);   
        }
        public ActionResult Update_sl_Cart(FormCollection form)
        {

            Cart cart = Session["Cart"] as Cart;
            int id_sp =int.Parse( form["ID_Sp"]);
            int Soluong = int.Parse(form["Soluong"]);
            cart.Update_sl_shop(id_sp,Soluong) ;
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_item(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_item = cart.Total_Soluong_Cart();
                ViewBag.slCart = total_item;
                return PartialView("BagCart");
        }
        public ActionResult MuaThanhCong()
        {

            return View();
        }
        public ActionResult CheckOut(FormCollection form)
        {

            try {
                Cart cart = Session["Cart"] as Cart;
                DatHang order = new DatHang();
                order.NgayDatHang = DateTime.Now;
                order.MaKH = form["MaKh"];
                order.MoTaDatHang = form["Mota_KH"];
                db.DatHang.Add(order);
                foreach (var item in cart.Items)
                {
                    ChiTietHangDat ChiTiet = new ChiTietHangDat();
                    ChiTiet.idDatHang = order.id;
                    ChiTiet.IdSanPham = item.shopping_sanpham.id;
                    ChiTiet.DonGia = item.shopping_sanpham.GiaKhuyenMai;
                    ChiTiet.SoLuongBan = item.shopping_sl;
                    db.ChiTietHangDat.Add(ChiTiet);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("MuaThanhCong", "ShoppingCart");
            }
            catch {
                return Content("Vui lòng kiểm tra lại đơn đặt hành");
            }
        }
    }
}