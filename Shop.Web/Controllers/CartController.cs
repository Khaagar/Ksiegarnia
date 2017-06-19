using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models;

namespace Shop.Web.Controllers
{
    public class CartController : Controller
    {


        // GET: Cart
        public PartialViewResult CartNavbar()
        {
            
            return PartialView(GetCart().SumCartItems());
        }

        [HttpPost]
        public ActionResult SubmitItem()
        {
            Book b = new Book();
            b.BookID = int.Parse(Request["bookID"]);
            b.Title = Request["bookTitle"];
            b.Author = Request["bookAuthor"];
            b.ReleaseDate = DateTime.Parse(Request["bookReleaseDate"]);
            b.Category = Request["bookCategory"];
            b.Publisher = Request["bookPublisher"];
            b.Price = decimal.Parse(Request["bookPrice"]);
            b.SuperPrice = bool.Parse(Request["bookSuperPrice"]);
            b.KindOfBook = Request["bookKindOfBook"]; 

            int q = int.Parse(Request["itemQuantity"]);
            string s = Request["selectedStorage"];
            GetCart().AddBook(b, q, s);
            return Redirect("/");
        }
        public ActionResult DeleteItem(int category = 1)
        {
            GetCart().RemoveBook(category);
            return RedirectToAction("ShowCart");
        }
        public ViewResult ShowCart()
        {
            return View(GetCart());
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

    }
}