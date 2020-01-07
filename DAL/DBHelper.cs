using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WebBookShop.DAL
{
    public static class DBHelper
    {
        static string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconstr"].ToString();
        static SqlConnection sqlCnt = new SqlConnection(connectString);
        public static SqlConnection BulidConnect()
        {
            return sqlCnt;
        }
        public static SqlCommand BindCommand(string cmd)
        {
            SqlCommand sqlCommand = sqlCnt.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmd;
            return sqlCommand;
        }
    }
}
