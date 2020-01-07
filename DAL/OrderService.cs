using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebBookShop.Models;

namespace WebBookShop.DAL
{
    public class OrderService
    {
        SqlConnection sqlCnt = DBHelper.BulidConnect();
        string sqlstr;
        SqlCommand cmd;
        public int CommitOrder(string orderID)
        {
            return 0;
        }

        public void Submit_Order(string userID, List<Book> order_books, double price)
        {
            sqlCnt.Open();
            sqlstr = "INSERT INTO OrderH(CustomerID,OrderPrice) VALUES('" + userID + "'," + price + ")";
            cmd = DBHelper.BindCommand(sqlstr);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.SelectCommand.ExecuteNonQuery();

            sqlstr = "SELECT MAX(OrderID) FROM OrderH";
            cmd = DBHelper.BindCommand(sqlstr);
            int id = int.Parse(cmd.ExecuteScalar().ToString());

            for(int i = 0; i < order_books.Count; i++)
            {
                sqlstr = "INSERT INTO OrderList VALUES(" + id + ",'" + order_books[i].BookId + "',"+ order_books[i].BookNum+")";
                cmd = DBHelper.BindCommand(sqlstr);
                cmd.ExecuteNonQuery();

                sqlstr = "UPDATE Book SET BookNum=BookNum-" + order_books[i].BookNum;
                cmd = DBHelper.BindCommand(sqlstr);
                cmd.ExecuteNonQuery();
            }

            sqlCnt.Close();
        }
    }
}
