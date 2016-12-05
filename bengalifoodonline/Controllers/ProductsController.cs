using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BengaliFoodOnline.Controllers
{
    public class ProductsController : Controller
    {
        private BengalifoodOnlineDbContext db = new BengalifoodOnlineDbContext();

        //
        // GET: /Products/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //return View(db.FoodmenuItems.ToList());
            List<FoodmenuItem> productList = db.FoodmenuItems.Where(p=>p.MainCourse==true).ToList();
    
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(@"Index", productList.ToPagedList(pageNumber, pageSize));

        }

        //
        // GET: /Products/Details/5

        public ActionResult Details(int id = 0)
        {
            FoodmenuItem foodmenuitem = db.FoodmenuItems.Find(id);
            if (foodmenuitem == null)
            {
                return HttpNotFound();
            }
            return View(foodmenuitem);
        }

        //
        // GET: /Products/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Products/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodmenuItem foodmenuitem)
        {
            if (ModelState.IsValid)
            {
                db.FoodmenuItems.Add(foodmenuitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodmenuitem);
        }

        //
        // GET: /Products/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FoodmenuItem foodmenuitem = db.FoodmenuItems.Find(id);
            if (foodmenuitem == null)
            {
                return HttpNotFound();
            }
            return View(foodmenuitem);
        }

        //
        // POST: /Products/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FoodmenuItem foodmenuitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodmenuitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodmenuitem);
        }

        //
        // GET: /Products/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FoodmenuItem foodmenuitem = db.FoodmenuItems.Find(id);
            if (foodmenuitem == null)
            {
                return HttpNotFound();
            }
            return View(foodmenuitem);
        }

        //
        // POST: /Products/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodmenuItem foodmenuitem = db.FoodmenuItems.Find(id);
            db.FoodmenuItems.Remove(foodmenuitem);
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