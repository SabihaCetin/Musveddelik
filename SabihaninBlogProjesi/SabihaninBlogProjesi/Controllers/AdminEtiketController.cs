using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomainEntity.Models;
using SabihaninBlogProjesi.Models;
using DAL;

namespace SabihaninBlogProjesi.Controllers
{
    [Authorize(Roles = "Admin, Yonetici")]

    public class AdminEtiketController : Controller
    {
        MyContext db = new MyContext();

        // GET: AdminEtiket
        public ActionResult Index()
        {
            return View(db.Etiketler.ToList());
        }

        // GET: AdminEtiket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiket etiket = db.Etiketler.Find(id);
            if (etiket == null)
            {
                return HttpNotFound();
            }
            return View(etiket);
        }

        // GET: AdminEtiket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminEtiket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EtiketID,Adi")] Etiket etiket)
        {
            if (ModelState.IsValid)
            {
                db.Etiketler.Add(etiket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etiket);
        }

        // GET: AdminEtiket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiket etiket = db.Etiketler.Find(id);
            if (etiket == null)
            {
                return HttpNotFound();
            }
            return View(etiket);
        }

        // POST: AdminEtiket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EtiketID,Adi")] Etiket etiket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etiket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etiket);
        }

        // GET: AdminEtiket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiket etiket = db.Etiketler.Find(id);
            if (etiket == null)
            {
                return HttpNotFound();
            }
            return View(etiket);
        }

        // POST: AdminEtiket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etiket etiket = db.Etiketler.Find(id);
            db.Etiketler.Remove(etiket);
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
