using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using WebBookShop.Models;

namespace WebBookShop.DAL
{
    public class CommentService
    {
        SqlConnection sqlCnt = DBHelper.BulidConnect();
        string sqlstr;
        SqlCommand cmd;
        public void addComment(string userID, string bookID, string txt)
        {
            sqlCnt.Open();
            sqlstr = "INSERT INTO Comment(CommentText,UserId,BookId) VALUES(@txt,@uid,@bid)";
            cmd = DBHelper.BindCommand(sqlstr);
            cmd.Parameters.AddWithValue("@txt", txt);
            cmd.Parameters.AddWithValue("@uid", userID);
            cmd.Parameters.AddWithValue("@bid", bookID);
            cmd.ExecuteNonQuery();
            sqlCnt.Close();
        }

        public DataSet getCommentsOfOneBook(string bookID)
        {
            DataSet ds = new DataSet();
            sqlCnt.Open();
            sqlstr = "SELECT * FROM Comment WHERE bookID='"+bookID+"'";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, sqlCnt);
            da.Fill(ds, "comm");
            sqlCnt.Close();
            
            return ds ;
        }
    }
}
