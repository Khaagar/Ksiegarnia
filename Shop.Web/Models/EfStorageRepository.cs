using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class EfStorageRepository : IStorageRepository
    {
        private EfDbContext context = new EfDbContext();
        public IEnumerable<Storage> Storages
        {
            get { return context.Storages; }
        }
    }
}