//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopBanDo.Areas.Admin.Models.Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietHangDat
    {
        public int id { get; set; }
        public Nullable<int> idDatHang { get; set; }
        public Nullable<int> IdSanPham { get; set; }
        public Nullable<decimal> DonGia { get; set; }
        public Nullable<int> SoLuongBan { get; set; }
    
        public virtual SanPham SanPham { get; set; }
        public virtual DatHang DatHang { get; set; }
    }
}