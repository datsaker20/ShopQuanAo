using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBanDo.Areas.Admin.Models.Framework
{
    public class DanhMucMetadata
    {
        [Display(Name="Mã Loại")]
        [Required(ErrorMessage ="Mã không được để trống")]
        public int id { get; set; }
        [Display(Name = "Tên loại danh mục")]
        [Required(ErrorMessage = "Tên không được để trống")]
        public string TenLoai { get; set; }
        [Display(Name = "Tên viết tắt")]
        public string TenVietTat { get; set; }
    }
}