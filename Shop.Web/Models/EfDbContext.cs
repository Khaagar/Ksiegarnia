using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Shop.Web.Models
{
    public class EfDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Storage> Storages { get; set; }
    }
}