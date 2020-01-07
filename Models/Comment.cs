using System;
using System.Collections.Generic;
using System.Text;

namespace WebBookShop.Models
{
    public class Comment
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public string CommentText { get; set; }

    }
}
