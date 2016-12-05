using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace BengaliFoodOnline.Controllers
{
    public class HomeController : Controller
    {
        BengalifoodOnlineDbContext db = new BengalifoodOnlineDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Title = "Gallery";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[Authorize(Users="*")]
        public ActionResult Order(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //if (Session["User"] == null)
            //{
            //    ViewBag.ReturnUrl = "~/Home/Order";
            //    Response.Redirect("/Account/Login?returnUrl="+ViewBag.ReturnUrl);
              
            //}

            // return View(@"Productlist", productList);
            List<FoodmenuItem> productList = db.FoodmenuItems.Where(p => p.MainCourse == true).ToList();

            int pageSize = 4;
            int pageNumber = (page ?? 1);
          
            ViewBag.Title = "Place an order";

            return View("Orderinit",productList.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult productdetails(string sortOrder, string currentFilter, string searchString, int? page)
        {
            List<FoodmenuItem> productList = db.FoodmenuItems.Where(p => p.MainCourse == true).ToList();

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            ViewBag.Title = "Place an order";

            return  PartialView("productdetails", productList.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Blog()
        {
            if (Session["User"] == null)
            {
                ViewBag.ReturnUrl = "~/Home/Blog";
                Response.Redirect("/Account/Login?returnUrl=" + ViewBag.ReturnUrl);

            }
            ViewBag.Title = "Place an order";
            return View();
        }
    }
}
