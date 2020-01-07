using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebBookShop.Models;

namespace WebBookShop.DAL
{
    public class UserService
    {
        SqlConnection sqlCnt = DBHelper.BulidConnect();
        string sqlstr;
        SqlCommand cmd;

        public int Add(WebBookShop.Models.User user)
        {
            sqlCnt.Open();
            sqlstr = "insert into Users(UserID,UserPwd) values (@id,@pwd)";
            cmd = DBHelper.BindCommand(sqlstr);

            cmd.Parameters.AddWithValue("@id", user.UserID);
            cmd.Parameters.AddWithValue("@pwd", user.UserPwd);

            cmd.ExecuteNonQuery();
            sqlCnt.Close();
            return 0;
        }
        public int Remove(string UserName)
        {
            return 0;
        }

        public string Exist(string userID)
        {
            sqlCnt.Open();
            sqlstr = "select UserPwd from Users where UserID=@userID";
            cmd = DBHelper.BindCommand(sqlstr);
            cmd.Parameters.AddWithValue("@userID", userID);
            if (cmd.ExecuteScalar() == null)
            {
                sqlCnt.Close();
                return null;
            }
            string pwd = cmd.ExecuteScalar().ToString();
            sqlCnt.Close();
            return pwd;
        }

        public DataSet getAllUserList()
        {
            throw new NotImplementedException();
        }

        public User WatchOneUser(string userID)
        {
            User user = new User();
            sqlCnt.Open();
            sqlstr = "select UserName,UserSex,UserBirth,UserSign,UserEmail,UserTelephone from Users where UserID=@userID";
            cmd = DBHelper.BindCommand(sqlstr);
            cmd.Parameters.AddWithValue("@userID", userID);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();


            user.UserID = userID;
            user.UserName = reader[0].ToString();
            user.UserSex = reader[1].ToString();
            user.UserBirth = reader.GetDateTime(2);
            user.UserSign = reader[3].ToString();
            user.UserEmail = reader[4].ToString();
            user.UserTelephone = reader[5].ToString();

            sqlCnt.Close();
            return user;
        }
        public int ModifyUser(User user)
        {
            sqlCnt.Open();
            sqlstr = "UPDATE Users SET UserName=@name,UserSex=@sex,UserBirth=@birth,UserEmail=@email,UserTelephone=@telephone,UserSign=@sign where UserID=@id";

            cmd = DBHelper.BindCommand(sqlstr);
            cmd.Parameters.AddWithValue("@name", user.UserName);
            cmd.Parameters.AddWithValue("@sex", user.UserSex);
            cmd.Parameters.AddWithValue("@birth", user.UserBirth.ToString());
            cmd.Parameters.AddWithValue("@email", user.UserEmail);
            cmd.Parameters.AddWithValue("@telephone", user.UserTelephone);
            cmd.Parameters.AddWithValue("@sign", user.UserSign);
            cmd.Parameters.AddWithValue("@id", user.UserID);
            int n = cmd.ExecuteNonQuery();

            sqlCnt.Close();
            return n;
        }
    }
}
