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
            if (db.Users.Count() == 0)
            {
                Users firstUser = new Users();
                firstUser.Login = "sulzhich";
                firstUser.Password = "1234";
                db.Users.Add(firstUser);
                db.SaveChanges();
            }
            return db.Users.FirstOrDefault(u => u.Login == item.Login && u.Password == item.Password);
        }
    }
}