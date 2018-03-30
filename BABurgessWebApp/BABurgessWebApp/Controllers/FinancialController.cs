using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BABurgessWebApp.Models;

namespace BABurgessWebApp.Controllers
{
    public class FinancialController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Financials
        public ActionResult Index()
        {
            return View(db.Financial.ToList());
        }

        // GET: Financials/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financial financial = db.Financial.Find(id);
            if (financial == null)
            {
                return HttpNotFound();
            }
            return View(financial);
        }

        // GET: Financials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Financials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Symbol,Name,Shares,Price,TOTAL")] Financial financial)
        {
            if (ModelState.IsValid)
            {
                financial.Id = Guid.NewGuid();
                db.Financial.Add(financial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(financial);
        }

        // GET: Financials/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financial financial = db.Financial.Find(id);
            if (financial == null)
            {
                return HttpNotFound();
            }
            return View(financial);
        }

        // POST: Financials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Symbol,Name,Shares,Price,TOTAL")] Financial financial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(financial);
        }

        // GET: Financials/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financial financial = db.Financial.Find(id);
            if (financial == null)
            {
                return HttpNotFound();
            }
            return View(financial);
        }

        // POST: Financials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Financial financial = db.Financial.Find(id);
            db.Financial.Remove(financial);
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
