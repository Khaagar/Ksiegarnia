using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Web.Models
{
    public interface IStorageRepository
    {
        IEnumerable<Storage> Storages { get; }
    }
}
