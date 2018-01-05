using DAL;
using DomainEntity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SabihaninBlogProjesi.Areas.Areas.Controllers
{
    public class MakaleController : Controller
    {
        MyContext db = new MyContext();
        // GET: Areas/Makale
        #region Makaleislemleri
        public ActionResult Index()
        {
            var makales = db.Makaleler.Include(m => m.Kategori);

            return View(makales.ToList());
        }

        // GET: Makale/Details/5
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

        // GET: Makale/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi");
            return View();
        }

        // POST: Makale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MakaleID,Baslik,Icerik,EklenmeTarihi,KategoriID,GoruntulenmeSayisi,Begeni,KullaniciID")] Makale makale, Resim r, HttpPostedFileBase resim)
        {

            if (ModelState.IsValid)
            {
                #region resimekleme
                var klasor = Server.MapPath("/content/Upload/");
                //resim geldiyse kaydet
                if (resim != null && resim.ContentLength != 0)
                {
                    if (resim.ContentLength > 2 * 1024 * 1024)
                    {
                        ModelState.AddModelError(null, "Resim boyutu max 2MB olabilir");
                    }
                    else
                    {
                        try
                        {
                            FileInfo fi = new FileInfo(resim.FileName);
                            var rasgele = Guid.NewGuid().ToString().Substring(0, 5);
                            var dosyaAdi = fi.Name + rasgele + fi.Extension;
                            resim.SaveAs(klasor + dosyaAdi);
                            r.OrtaBoyut = dosyaAdi;
                            makale.Resim.Add(r);
                        }
                        catch { }
                    }
                    if (ModelState.IsValid)
                        new BLL.BaseRepository<Resim>().Insert(r);
                    #endregion
                    db.Resimler.Add(r);
                    db.Makaleler.Add(makale);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    db.Makaleler.Add(makale);
                    db.SaveChanges();
                }


            }
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi", makale.KategoriID);
            return View(makale);
        }

        // GET: Makale/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi", makale.KategoriID);
            return View(makale);
        }

        // POST: Makale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MakaleID,Baslik,Icerik,EklenmeTarihi,KategoriID,GoruntulenmeSayisi,Begeni,KullaniciID")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi", makale.KategoriID);
            return View(makale);
        }

        // GET: Makale/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Makale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Makale makale = db.Makaleler.Find(id);
            db.Makaleler.Remove(makale);
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
        public ActionResult Ekle()
        {
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "MakaleID,Baslik,Icerik,EklenmeTarihi,KategoriID,GoruntulenmeSayisi,Begeni,KullaniciID")] Makale makale, Resim r, HttpPostedFileBase resim)
        {

            if (ModelState.IsValid)
            {
                #region resimekleme
                var klasor = Server.MapPath("/content/Upload/");
                //resim geldiyse kaydet
                if (resim != null && resim.ContentLength != 0)
                {
                    if (resim.ContentLength > 2 * 1024 * 1024)
                    {
                        ModelState.AddModelError(null, "Resim boyutu max 2MB olabilir");
                    }
                    else
                    {
                        try
                        {
                            FileInfo fi = new FileInfo(resim.FileName);
                            var rasgele = Guid.NewGuid().ToString().Substring(0, 5);
                            var dosyaAdi = fi.Name + rasgele + fi.Extension;
                            resim.SaveAs(klasor + dosyaAdi);
                            r.OrtaBoyut = dosyaAdi;
                            makale.Resim.Add(r);
                        }
                        catch { }
                    }
                    if (ModelState.IsValid)
                        new BLL.BaseRepository<Resim>().Insert(r);
                    #endregion
                    db.Resimler.Add(r);
                    db.Makaleler.Add(makale);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    db.Makaleler.Add(makale);
                    db.SaveChanges();
                }


            }
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi", makale.KategoriID);
            return View(makale);
        }
        #endregion
    }
}