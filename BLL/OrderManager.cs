using System;
using System.Collections.Generic;
using System.Text;
using WebBookShop.Models;

namespace WebBookShop.BLL
{
    public class OrderManager
    {
        public int CommitOrder(string orderID)
        {
            return new WebBookShop.DAL.OrderService().CommitOrder(orderID);
        }

        public void Submit_Order(string userID, List<Book> order_books, double price)
        {
            new DAL.OrderService().Submit_Order(userID, order_books, price);
        }   
    }
}
