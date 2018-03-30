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

        // GET: FinancialTrading
        public ActionResult Index()
        {
            return View(db.FinancialTradingModels.ToList());
        }

        // GET: FinancialTrading/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialTradingModels financialTradingModels = db.FinancialTradingModels.Find(id);
            if (financialTradingModels == null)
            {
                return HttpNotFound();
            }
            return View(financialTradingModels);
        }

        // GET: FinancialTrading/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinancialTrading/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Symbol")] FinancialTradingModels financialTradingModels)
        {
            if (ModelState.IsValid)
            {
                db.FinancialTradingModels.Add(financialTradingModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(financialTradingModels);
        }

        // GET: FinancialTrading/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialTradingModels financialTradingModels = db.FinancialTradingModels.Find(id);
            if (financialTradingModels == null)
            {
                return HttpNotFound();
            }
            return View(financialTradingModels);
        }

        // POST: FinancialTrading/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Symbol")] FinancialTradingModels financialTradingModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financialTradingModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(financialTradingModels);
        }

        // GET: FinancialTrading/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialTradingModels financialTradingModels = db.FinancialTradingModels.Find(id);
            if (financialTradingModels == null)
            {
                return HttpNotFound();
            }
            return View(financialTradingModels);
        }

        // POST: FinancialTrading/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinancialTradingModels financialTradingModels = db.FinancialTradingModels.Find(id);
            db.FinancialTradingModels.Remove(financialTradingModels);
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
