using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class Cart
    {
           public List<CartLine> lineCollection = new List<CartLine>();

        

        public void AddBook(Book book = null, int quantity = 1, string device = null)
        {
            try
            {
                CartLine line = lineCollection.Where(x => x.Book.BookID == book.BookID).FirstOrDefault();
                line.Quantity += quantity;
            }
            catch (NullReferenceException)
            {
                lineCollection.Add(new CartLine { Book = book, Quantity = quantity, DataStorageDevice = device });
            }
        }

        public void RemoveBook(int id)
        {
            lineCollection.RemoveAll(x => x.Book.BookID == id);
        }

        public int SumCartItems()
        {
            int count = 0 ;
            foreach(CartLine i in lineCollection)
            {
                count += i.Quantity;
            }
            return count;
        }

        public class CartLine 
        {
            public Book Book { get; set; }
            public int Quantity { get; set; }
            public string DataStorageDevice { get; set; }

            public decimal SumCartValue()
            {
                return Book.Price * Quantity;
            }
        }
    }
}