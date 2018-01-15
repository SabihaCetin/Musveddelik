using DAL;
using DomainEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SabihaninBlogProjesi.Controllers
{
    public class UyeController : Controller
    {
            MyContext db = new MyContext();
        // GET: Uye
        public ActionResult Index()
        {

            return View(db.Makaleler.ToList());
        }

        // GET: Uye/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // GET: Uye/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uye/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Uye/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Uye/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Uye/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Uye/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
