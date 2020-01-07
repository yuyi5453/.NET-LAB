using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WebBookShop.Models
{
    public class Book
    {
        public string BookId { get; set; }
        public string BookName { get; set; }
        public double BookPrice { get; set; }
        public int  BookNum { get; set; }
        public string PublicName { get; set; }
        public string BookImgUrl { get; set; }
    }
}
