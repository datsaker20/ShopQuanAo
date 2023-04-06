using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopBanDo.Areas.Admin.Models.Framework
{
    [MetadataType(typeof(SanPhamMetadata))]
    public partial class SanPham
    {
        //public SanPham()
        //{
          //  HinhAnh = "fileName.jpg";
       // }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}