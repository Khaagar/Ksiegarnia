using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models;

namespace Shop.Web.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;

        public BookController(IBookRepository bookRepository)
        {
            this.repository = bookRepository;
        }

        public ViewResult List(string category = null)
        {
            HttpContext.Application["SelectedCategory"] = category;
            var listRepo = FilterByCategory(category);
            return View(listRepo);  
        }

        public IEnumerable<Book> FilterByCategory(string category = null)
        {
            switch (category)
            {
                case "Audiobooki":
                    return repository.Books.Where(x => x.KindOfBook == "a");
                case "E-booki":
                    return repository.Books.Where(x => x.KindOfBook == "e");
                case "Nowości":
                    return repository.Books.Where(x => ((DateTime.Now - x.ReleaseDate).Days < 15) && ((DateTime.Now - x.ReleaseDate).Days >= 0));
                case "Zapowiedzi":
                    return repository.Books.Where(x => ((x.ReleaseDate - DateTime.Now).Days < 15) && ((x.ReleaseDate - DateTime.Now).Days > 0));
                case "Super okazje":
                    return repository.Books.Where(x => x.SuperPrice);
                default: return repository.Books;
            }
        }

        [HttpPost]
        public ActionResult SearchList()
        {
            string searchCategory = Request["searchCategory"];
            string searchText = Request["searchText"];
            string category = HttpContext.Application["SelectedCategory"].ToString();
            var listRepo = FilterByCategory(category);

            if (searchCategory == "Tytuł")
            {
                return View("List",listRepo.Where(x => x.Title.ToUpper().Contains(searchText.ToUpper())));
            }
            else if (searchCategory == "Autor")
            {
                return View("List", listRepo.Where(x => x.Author.ToUpper().Contains(searchText.ToUpper())));
            }
            return View("List", listRepo);

        }

        public PartialViewResult Popup(int category = 1)
        {
            return PartialView(repository.Books.Where(x=>x.BookID==category).FirstOrDefault());
        }

        public PartialViewResult SearchBar()
        {
            return PartialView();
        }

        public PartialViewResult EmptyList()
        {
            return PartialView();
        }

    }
}