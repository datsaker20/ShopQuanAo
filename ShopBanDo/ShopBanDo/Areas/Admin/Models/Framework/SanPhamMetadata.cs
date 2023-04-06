using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBanDo.Areas.Admin.Models.Framework
{
    public class SanPhamMetadata

    {
        

        [Display(Name="Mã Sản Phẩm")]
        [Required(ErrorMessage = "Mã không được để trống")]
        public int id { get; set; }
        [Display(Name = "Mã Loại")]
        [Required(ErrorMessage = "Mã không được để trống")]
        public Nullable<int> idLoai { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage = "Tên không được để trống")]
        public string TenSanPham { get; set; }
        [Display(Name = "Giá Bán")]
        public Nullable<decimal> GiaBan { get; set; }
        [Display(Name = "Giá Khuyến Mại")]
        public Nullable<decimal> GiaKhuyenMai { get; set; }
        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }
        [Display(Name = "Thông Tin Chi Tiết")]
        public string ThongTinChiTiet { get; set; }
        [Display(Name = "Tên Viết Tắt")]
        public string TenVietTat { get; set; }
        [Display(Name = "Số Lượng")]
        public Nullable<int> SoLuong { get; set; }
        [Display(Name = "Hình Ảnh")]
        public string HinhAnh { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
     



    }
}