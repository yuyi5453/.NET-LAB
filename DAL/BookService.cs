using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WebBookShop.Models;

namespace WebBookShop.DAL
{
    public class BookService
    {
        SqlConnection sqlCnt = DBHelper.BulidConnect();
        string sqlstr;
        SqlCommand cmd;

        public DataSet GetAllList()
        {
            sqlCnt.Open();
            sqlstr = "select * from Book";
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(sqlstr, sqlCnt);
            sda.Fill(ds,"Book");
            sqlCnt.Close();
            return ds;
        }

        //增加一本书
        public int Add(WebBookShop.Models.Book book)
        {
            sqlCnt.Open();
            sqlstr = "insert into Book(BookId,BookName,BookNum,BookPrice,BookImgUrl) values(@bookId,@bookName,@bookNum,@bookPrice,@bookImgUrl)";
            cmd = DBHelper.BindCommand(sqlstr);              //创建SqlCommand对象

            cmd.Parameters.AddWithValue("@bookId", book.BookId);
            cmd.Parameters.AddWithValue("@bookImgUrl", book.BookImgUrl);

            cmd.Parameters.Add("@bookName", SqlDbType.VarChar,50);
            cmd.Parameters["@bookName"].Value = book.BookName;

            cmd.Parameters.Add("@bookNum", SqlDbType.Int);
            cmd.Parameters["@bookNum"].Value = book.BookNum ;

            cmd.Parameters.Add("@bookPrice", SqlDbType.Float);
            cmd.Parameters["@bookPrice"].Value = book.BookPrice;

            cmd.ExecuteNonQuery();
            sqlCnt.Close();
            return 0;
        }

        public DataSet GetSomeList(string searchBookName)
        {
            DataSet ds = new DataSet();
            sqlCnt.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            sqlstr = "SELECT * FROM Book WHERE BookName LIKE '%" + searchBookName+"%'";
            cmd = DBHelper.BindCommand(sqlstr);
            da.SelectCommand = cmd;
            da.Fill(ds, "book");
            sqlCnt.Close();

            return ds;
        }

        public Book getOneBook(string bookID)
        {
            Book book = new Book();
            sqlCnt.Open();
            sqlstr = "select * from Book where BookId=@bookID";
            cmd = DBHelper.BindCommand(sqlstr);
            cmd.Parameters.AddWithValue("@bookID", bookID);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();


            book.BookId = bookID;
            book.BookName = reader[1].ToString();
            book.BookPrice = Math.Round(reader.GetDouble(2),2);
            book.BookNum = reader.GetInt32(3) ;
            book.PublicName = reader[4].ToString();
            book.BookImgUrl = reader[5].ToString();

            sqlCnt.Close();
            return book;
        }



        //删除一本书
        public int Remove(string bookId)
        {
            string sqlstr = "DELET * FROM Book WHERE BookId=@bookId";
            cmd.Parameters.AddWithValue("@bookId", bookId);
            cmd.ExecuteNonQuery();
            sqlCnt.Close();
            return 0;
        }
        public int ModifyBookName(string bookId,string newName)
        {
            return 0;
        }
        public int ModifyBookNum(string BookId,int num)
        {
            return 0;
        }
    }
}
