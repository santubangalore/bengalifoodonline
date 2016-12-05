using BengaliFoodOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BengaliFoodOnline.Areas.Foods.Controllers
{
    public class UserController : ApiController
    {
        BengalifoodOnlineDbContext db = new BengalifoodOnlineDbContext();

        [HttpGet]
        public HttpResponseMessage GetDefaultUser()
        {
            string email="";
            if (HttpContext.Current.Session["User"] != null)
            {
                email = Convert.ToString(HttpContext.Current.Session["User"].ToString());

                var user = db.Customers.Where(p => p.Email == email).SingleOrDefault();
                if (user != null)
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, user);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "");
            }
        }
    }
}
