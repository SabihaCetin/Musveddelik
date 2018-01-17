using DAL;
using DomainEntity.Models;
using Microsoft.AspNet.Identity;
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
        [Authorize]
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
        [Authorize]
        // GET: Uye/Create
        public ActionResult Profil()
        {
            var aktifuyeID = User.Identity.GetUserId();
            if (aktifuyeID == null)
            {
                return RedirectToAction("Login", "Account", null);
            }
            var g = db.Users.Where(x => x.Id == aktifuyeID).Select(y=>y.UserName).FirstOrDefault();


            var girisyapan = db.Makaleler.Where(x => x.Kullanici.Email == g).FirstOrDefault();

            return View(girisyapan);
        }

        public ActionResult gir()
        {
            return View();
        }

        public ActionResult gir2()
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
