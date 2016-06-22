using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopService.Model;


namespace ShopService.Repositories
{
    public class AuthenticationRepository
    {
        private static WcfDataModel db = new WcfDataModel();

        public static Users Check(Users item)
        {
            return db.Users.FirstOrDefault(u => u.Login == item.Login && u.Password == item.Password);
        }
    }
}