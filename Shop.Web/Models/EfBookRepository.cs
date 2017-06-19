using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class EfBookRepository : IBookRepository
    {
        private EfDbContext context = new EfDbContext();
        public IEnumerable<Book> Books
        {
            get { return context.Books; }
        }
    }
}