using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WebBookShop.Models;

namespace WebBookShop.BLL
{
    public class BookManager
    {
        public List<Book> GetAllBookList()
        {
            List<Book> books = new List<Book>();
            DataSet ds = new DAL.BookService().GetAllList();
            DataTable dt = ds.Tables[0];
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Book book = new Book();
                book.BookId = dt.Rows[i][0].ToString();
                book.BookName = dt.Rows[i][1].ToString();
                book.BookPrice = double.Parse(dt.Rows[i][2].ToString());
                book.BookNum = int.Parse(dt.Rows[i][3].ToString());
                book.PublicName = dt.Rows[i][4].ToString();
                book.BookImgUrl = dt.Rows[i][5].ToString();

                books.Add(book);
            }
            return books;
            
        }

        public List<Book> GetSomeBookList(string searchBookName)
        {
            List<Book> books = new List<Book>();
            DataSet ds = new DAL.BookService().GetSomeList(searchBookName);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Book book = new Book();
                book.BookId = dt.Rows[i][0].ToString();
                book.BookName = dt.Rows[i][1].ToString();
                book.BookPrice = double.Parse(dt.Rows[i][2].ToString());
                book.BookNum = int.Parse(dt.Rows[i][3].ToString());
                book.PublicName = dt.Rows[i][4].ToString();
                book.BookImgUrl = dt.Rows[i][5].ToString();

                books.Add(book);
            }
            return books;
        }

        public Book getOneBook(string bookID)
        {

            return new DAL.BookService().getOneBook(bookID);
        }

        public int Add(WebBookShop.Models.Book book)
        {
            return new WebBookShop.DAL.BookService().Add(book);
        }
        public int Remove(string BookName)
        {
            return new WebBookShop.DAL.BookService().Remove(BookName);
        }
        public int ModifyBookName(string BookName, string newName)
        {
            return new WebBookShop.DAL.BookService().ModifyBookName(BookName,newName);
        }
        public int ModifyBookNum(string BookName, int num)
        {
            return new WebBookShop.DAL.BookService().ModifyBookNum(BookName,num);
        }
    }
}
