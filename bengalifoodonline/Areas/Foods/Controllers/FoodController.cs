using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BengaliFoodOnline.Models;
using System.Threading.Tasks;

//using BL=NetquestFoodBusinessLayer;
namespace BengaliFoodOnline.Controllers
{
    public class FoodController : ApiController
    {
       // List<FoodmenuItem> foodMenulist = new List<FoodmenuItem>();
       // List<BL.FoodmenuItem> foodMenulist = new List<BL.FoodmenuItem>();
        BengalifoodOnlineDbContext db = new BengalifoodOnlineDbContext();
        [HttpGet]
        public HttpResponseMessage GetAllFood()
        {
            List<FoodmenuItem> Menulist;
            try
            {
                //using (BL.FoodItemManager manager= new BL.FoodItemManager())
                //{
                    Menulist = db.FoodmenuItems.Where(t => t.MainCourse == true).ToList();
                    //foodMenulist = manager.GetFoodmenuItems();
                //}
            }
            catch (Exception ex)
            {
                return null;
            }
            //return Json(bookList, JsonRequestBehavior.AllowGet);
            return Request.CreateResponse(HttpStatusCode.OK, Menulist);
        }

    }
}
