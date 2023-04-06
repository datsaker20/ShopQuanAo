using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBanDo.Areas.Admin.Models.Framework
{
    public class KhanhHangMetadata
    {
        public int id { get; set; }
        public string MaKh { get; set; }
      
        public string EmailKH { get; set; }
    
        public string DiaChi { get; set; }
      
        public string SoDienThoai { get; set; }
    }
}