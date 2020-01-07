using System;
using System.Collections.Generic;
using System.Text;
using WebBookShop.Models;
using System.Data;

namespace WebBookShop.BLL
{
    public class UserManager
    {
        public int Add(WebBookShop.Models.User user)
        {
            return new WebBookShop.DAL.UserService().Add(user);
        }
        public int Remove(string UserName)
        {
            return new WebBookShop.DAL.UserService().Remove(UserName);
        }


        public User watchOneUser(string userID)
        {
            return new WebBookShop.DAL.UserService().WatchOneUser(userID);
        }

        public string Exist(string userID)
        {
            return new DAL.UserService().Exist(userID);
        }

        public class getAllUserList : List<User>
        {
            List<User> users = new List<User>();
            DataSet ds = new DAL.UserService().getAllUserList();

        }

        public int ModifyUser(User user)
        {
            return new DAL.UserService().ModifyUser(user);
        }
    }
}
