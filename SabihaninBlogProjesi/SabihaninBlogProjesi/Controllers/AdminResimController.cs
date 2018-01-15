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
    public class AdminResimController : Controller
    {
        MyContext db = new MyContext();

        // GET: AdminResim
        public ActionResult Index()
        {
            var Resimler = db.Resimler.Include(r => r.Makale);
            return View(Resimler.ToList());
        }

        // GET: AdminResim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resim resim = db.Resimler.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        // GET: AdminResim/Create
        public ActionResult Create()
        {
            ViewBag.MakaleID = new SelectList(db.Makaleler, "MakaleID", "Baslik");
            return View();
        }

        // POST: AdminResim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResimID,KucukBoyut,OrtaBoyut,BuyukBoyut,Video,MakaleID")] Resim resim)
        {
            if (ModelState.IsValid)
            {
                db.Resimler.Add(resim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MakaleID = new SelectList(db.Makaleler, "MakaleID", "Baslik", resim.MakaleID);
            return View(resim);
        }

        // GET: AdminResim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resim resim = db.Resimler.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            ViewBag.MakaleID = new SelectList(db.Makaleler, "MakaleID", "Baslik", resim.MakaleID);
            return View(resim);
        }

        // POST: AdminResim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResimID,KucukBoyut,OrtaBoyut,BuyukBoyut,Video,MakaleID")] Resim resim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MakaleID = new SelectList(db.Makaleler, "MakaleID", "Baslik", resim.MakaleID);
            return View(resim);
        }

        // GET: AdminResim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resim resim = db.Resimler.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        // POST: AdminResim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resim resim = db.Resimler.Find(id);
            db.Resimler.Remove(resim);
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
