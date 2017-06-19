using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models;

namespace Shop.Web.Controllers
{
    public class StorageController : Controller
    {
        private IStorageRepository repository;

        public StorageController(IStorageRepository storageRepository)
        {
            this.repository = storageRepository;
        }


        // GET: Storage
        public PartialViewResult StorageSelect()
        {
            return PartialView(repository.Storages);
        }
    }
}