using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class TabsController : Controller
    {
        public List<String> tabs = new List<String>();

        public PartialViewResult Menu(string category = "Wszystkie")
        {
            HttpContext.Application["SelectedCategory"] = category;
            ViewBag.SelectedCategory = category;
            tabs.Add("Wszystkie");
            tabs.Add("Audiobooki");
            tabs.Add("E-booki");
            tabs.Add("Nowości");
            tabs.Add("Zapowiedzi");
            tabs.Add("Super okazje");
            return PartialView(tabs);
        }
    }
}