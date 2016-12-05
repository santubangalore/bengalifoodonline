using BengaliFoodOnline.Configuration;
using BengaliFoodOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BengaliFoodOnline.Controllers
{
    public class CheckoutController : Controller
    {
        BengalifoodOnlineDbContext storeDB = new BengalifoodOnlineDbContext();
        AppConfigurations appConfig = new AppConfigurations();

        public List<String> CreditCardTypes { get { return appConfig.CreditCardType; } }
        public List<String> PaymentTypes { get { return appConfig.PaymentType;} }

        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            ViewBag.CreditCardTypes = CreditCardTypes;
            ViewBag.PaymentTypes = PaymentTypes;
            //var previousOrder = storeDB.Orders.FirstOrDefault(x => x.CustomerID == User.Identity.Name);

            //if (previousOrder != null)
            //    return View(previousOrder);
            //else
                return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public JsonResult AddressAndPayment(Order objOrder)
        {
            ViewBag.CreditCardTypes = CreditCardTypes;
            ViewBag.PaymentTypes = PaymentTypes;

           // string result =  values[9];
        

            //var order = new Order();
            //TryUpdateModel(order);
            //order.CreditCard = result;

            try
            {
                 var cart = ShoppingCart.GetCart(this.HttpContext);
                 objOrder.Total = cart.GetTotal();

                 objOrder.CreatedDate = DateTime.Now;

            // Set up our ViewModel
            //var viewModel = new ShoppingCartViewModel
            //{
            //    CartItems = cart.GetCartItems(),
            //    CartTotal = Convert.ToInt32(cart.GetTotal())
            //};

                //order.Username = values["FirstName"] + values["LastName"];
                    
                //order.Email = User.Identity.Name;
                //order.OrderDate = DateTime.Now;
                //order.PaymentType = values["PaymentType"];
                //order.Phone = values["Phone"];
                //order.Address = values["Address"];
                //order.PaymentType = values["PaymentType"];
                //order.PostalCode = values["PostalCode"];
                //order.State = values["state"];
               
               

                 if (objOrder.SaveInfo && !objOrder.Username.Equals("guest@guest.com"))
                 {


                     //

                 }


                //Save Order
                 storeDB.Orders.Add(objOrder);
                 storeDB.SaveChanges();
                 objOrder = cart.CreateOrder(objOrder);
              
                 

            }
            catch (Exception exx)
            {
                //Invalid - redisplay with errors
                return Json(objOrder);
            }

            return Json(objOrder);
        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id );
                    //&& o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

        //private static RestResponse SendOrderMessage(String toName, String subject, String body, String destination)
        //{
        //    RestClient client = new RestClient();
        //    //fix this we have this up top too
        //    AppConfigurations appConfig = new AppConfigurations();
        //    client.BaseUrl = "https://api.mailgun.net/v2";
        //    client.Authenticator =
        //           new HttpBasicAuthenticator("api",
        //                                      appConfig.EmailApiKey);
        //    RestRequest request = new RestRequest();
        //    request.AddParameter("domain",
        //                        appConfig.DomainForApiKey, ParameterType.UrlSegment);
        //    request.Resource = "{domain}/messages";
        //    request.AddParameter("from", appConfig.FromName + " <" + appConfig.FromEmail + ">");
        //    request.AddParameter("to", toName + " <" + destination + ">");
        //    request.AddParameter("subject", subject);
        //    request.AddParameter("html", body);
        //    request.Method = Method.POST;
        //    IRestResponse executor = client.Execute(request);
        //    return executor as RestResponse;
        //}
    }
}
