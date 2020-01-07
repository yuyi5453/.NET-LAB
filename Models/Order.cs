using System;
using System.Collections.Generic;
using System.Text;

namespace WebBookShop.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public List<Book> Books { get; set; }
        public double OrderPrice { get; set; }
        public string UserID { get; set; }
    }
}
