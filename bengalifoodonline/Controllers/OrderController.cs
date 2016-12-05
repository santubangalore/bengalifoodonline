using BengaliFoodOnline.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BengaliFoodOnline.Controllers
{
    public class OrderController : Controller
    {
        private BengalifoodOnlineDbContext db = new BengalifoodOnlineDbContext();

        //
        // GET: /Order/

        public ActionResult Index()
        {
            //ObjectResult<NQS_ShowOrderDetails_Result> PendingOrders = db.NQS_ShowOrderDetails(fromdate, todate, orderno);

            //List<PendingOrderViewModel> viewProducts = PendingOrders.Select(p => new PendingOrderViewModel { OrderId=p.OrderId,  CreatedDate = p.CreatedDate, 
            //    FoodItemName=p.FoodItemName, 
            //    ItemQuantity = p.ItemQuantity, FirstName=p.FirstName,Phone=p.Phone, Address=p.Address, OrderDate=p.OrderDate }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult GetPendingOrders(PendingRequest prq)
        {
            ObjectResult<NQS_ShowOrderDetails_Result> PendingOrders = db.NQS_ShowOrderDetails(prq.Fromdate, prq.Todate, prq.Orderno);

            PendingOrderViewModel viewProducts;//= PendingOrders.Select(p => new PendingOrderViewModel
            //{
            //    OrderId = p.OrderId,
            //    CreatedDate = p.CreatedDate,
            //    //FoodItemName = p.FoodItemName,
            //    //ItemQuantity = p.ItemQuantity,
            //    FirstName = p.FirstName,
            //    Phone = p.Phone,
            //    Address = p.Address,
            //    OrderDate = p.OrderDate
            //}).ToList();

            viewProducts = Converter.ConvertDLtoBL(PendingOrders);
            return View(viewProducts);
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Order/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        //
        // GET: /Order/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Order/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}