using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebAssignment;

namespace MVCWebAssignment.Controllers
{
    public class ProductsTblsController : Controller
    {
        private DbProductEntities db = new DbProductEntities();

        // GET: ProductsTbls
        public ActionResult Index()
        {
            var productsTbls = db.ProductsTbls.Include(p => p.DetailsTbl);
            return View(productsTbls.ToList());
        }

        // GET: ProductsTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsTbl productsTbl = db.ProductsTbls.Find(id);
            if (productsTbl == null)
            {
                return HttpNotFound();
            }
            return View(productsTbl);
        }

        // GET: ProductsTbls/Create
        public ActionResult Create()
        {
            ViewBag.Model_Id = new SelectList(db.DetailsTbls, "Model_Id", "Model_Name");
            return View();
        }

        // POST: ProductsTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Prod_Name,Prod_Rate,Model_Id")] ProductsTbl productsTbl)
        {
            if (ModelState.IsValid)
            {
                db.ProductsTbls.Add(productsTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Model_Id = new SelectList(db.DetailsTbls, "Model_Id", "Model_Name", productsTbl.Model_Id);
            return View(productsTbl);
        }

        // GET: ProductsTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsTbl productsTbl = db.ProductsTbls.Find(id);
            if (productsTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Model_Id = new SelectList(db.DetailsTbls, "Model_Id", "Model_Name", productsTbl.Model_Id);
            return View(productsTbl);
        }

        // POST: ProductsTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Prod_Name,Prod_Rate,Model_Id")] ProductsTbl productsTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Model_Id = new SelectList(db.DetailsTbls, "Model_Id", "Model_Name", productsTbl.Model_Id);
            return View(productsTbl);
        }

        // GET: ProductsTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsTbl productsTbl = db.ProductsTbls.Find(id);
            if (productsTbl == null)
            {
                return HttpNotFound();
            }
            return View(productsTbl);
        }

        // POST: ProductsTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductsTbl productsTbl = db.ProductsTbls.Find(id);
            db.ProductsTbls.Remove(productsTbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
