using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBanDo.Areas.Admin.Models.Framework;
namespace ShopBanDo.Areas.Client.Models
{
    public class CartItem
    {

        public  SanPham shopping_sanpham { get; set; }
        public int shopping_sl { get; set; }

    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }

        }
        public void Add (SanPham sp,int sl = 1)
        {
            var item = items.FirstOrDefault(x => x.shopping_sanpham.id == sp.id);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    shopping_sanpham = sp,
                    shopping_sl = sl


                });
            }
            else
            {
                    item.shopping_sl += sl;
            }
        }
        public void Update_sl_shop(int id, int sl)
        {
            var item = items.Find(x => x.shopping_sanpham.id == id);
            if(item!=null)
            {
                item.shopping_sl = sl;
            }    
        }
        public double Total_Money()
        {

            var total = items.Sum(x => x.shopping_sanpham.GiaKhuyenMai * x.shopping_sl);
            return (double)total;
        }
        public void Remove_item(int id)
        {

            items.RemoveAll(x => x.shopping_sanpham.id == id);
        }
        public int Total_Soluong_Cart()
        {
            return items.Sum(x => x.shopping_sl);
        }
        public void ClearCart()
        {
            items.Clear();
        }

    }
}
