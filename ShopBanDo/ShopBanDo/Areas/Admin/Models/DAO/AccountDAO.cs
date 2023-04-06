using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBanDo.Areas.Admin.Models.DAO
{
    public class AccountDAO
    {
       private static  Models.Framework.ShopQuanAoEntities db = new Models.Framework.ShopQuanAoEntities();
        public AccountDAO()
        {
           
        }
        public static bool checkLogin(string username,string password)
        {
            int num = db.Account.Count(x => x.username == username && x.password == password);
            return num==1;
        }
    }
}