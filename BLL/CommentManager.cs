using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WebBookShop.Models;

namespace WebBookShop.BLL
{
    public class CommentManager
    {
        public void addComment(string userID, string bookID, string txt)
        {
            new DAL.CommentService().addComment(userID, bookID,txt);
        }

        public List<Comment> getCommentsOfOneBook(string bookID)
        {
            DataSet ds = new DAL.CommentService().getCommentsOfOneBook(bookID);
            List<Comment> comments = new List<Comment>();
            DataTable dt = ds.Tables["comm"];
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Comment cm = new Comment();
                cm.CommentText = dt.Rows[i][1].ToString();
                cm.UserId = dt.Rows[i][2].ToString();

                comments.Add(cm);
            }

            return comments;
        }
    }
}
