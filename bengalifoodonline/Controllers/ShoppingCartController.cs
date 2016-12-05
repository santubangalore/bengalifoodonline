using BengaliFoodOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BengaliFoodOnline.Controllers
{
    public class ShoppingCartController : Controller
    {
        //
        // GET: /ShoppinCart/
        BengalifoodOnlineDbContext db = new BengalifoodOnlineDbContext();
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = Convert.ToInt32(cart.GetTotal())
            };
            return View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

        [HttpPost]
        public ActionResult AddToCart(OrderItem orderitem)
        {
            // Retrieve the item from the database
            var addedItem = db.FoodmenuItems
                .Single(item => item.FoodItemID == orderitem.MenuItemID);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            int count = cart.AddToCart(addedItem,orderitem.Quantity,orderitem.Odate);

            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(addedItem.FoodItemName) +
                    " has been added to your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
               // ItemCount = count,
                DeleteId = orderitem.MenuItemID
            };
            return Json(results);
        }
    }
}
