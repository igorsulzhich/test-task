﻿using System.Linq;
using ShopService.Model;


namespace ShopService.Repositories
{
    public class AuthenticationRepository
    {
        private static WcfDataModel db = new WcfDataModel();

        public static Users Check(Users item)
        {
            try
            {
                if (db.Users.FirstOrDefault() == null)
                {
                    Users firstUser = new Users();
                    firstUser.Login = "sulzhich";
                    firstUser.Password = "1234";
                    db.Users.Add(firstUser);
                    db.SaveChanges();
                }
                return db.Users.FirstOrDefault(u => u.Login == item.Login && u.Password == item.Password);
            }
            catch
            {
                return null;
            }
        }
    }
}