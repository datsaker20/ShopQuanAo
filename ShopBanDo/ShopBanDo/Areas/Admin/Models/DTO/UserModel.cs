using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBanDo.Areas.Admin.Models.DTO
{
    public class UserModel
    {
        [Required(ErrorMessage ="Tài Khoản không được để trống")]
        public string username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}