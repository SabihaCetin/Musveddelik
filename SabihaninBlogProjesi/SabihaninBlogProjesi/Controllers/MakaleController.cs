﻿using BLL;
using DAL;
using DomainEntity.Models;
using Microsoft.AspNet.Identity;
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
        MakaleRep mrep = new MakaleRep();
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

        [HttpPost]
        public void YorumYap(string yorum, int Makaleid)
        {
            Kullanici k = new Kullanici();
            YorumRep yrep = new YorumRep();
            var kulID = User.Identity.GetUserId();

            var kul = db.Users.Where(m => m.Id == kulID).FirstOrDefault();
           
            var makale = db.Makaleler.Where(x => x.MakaleID == Makaleid).FirstOrDefault();
            db.Yorumlar.Add(new DomainEntity.Yorum { Kullanici = kul, Makale = makale, EklenmeTarihi = DateTime.Now, YorumIcerik = yorum });
            db.SaveChanges();
            //return Json(false, JsonRequestBehavior.AllowGet);
        }

        // GET: Makale/Create
        // GET: AdminMakale/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi");
            return View();
        }

        // POST: AdminMakale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MakaleID,Baslik,Icerik,EklenmeTarihi,KategoriID,GoruntulenmeSayisi,Begeni,KullaniciID")] Makale makale, HttpPostedFileBase resim, string[] etik, string kateg)
        {
            Resim r = new Resim();
            if (ModelState.IsValid)
            {
                #region resimekleme
                var klasor = Server.MapPath("/Content/Upload/");
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
                            makale.Resimler.Add(r);
                            new BLL.BaseRepository<Resim>().Insert(r);
                        }
                        catch { }
                    }
                }
            }
            #endregion
            if (ModelState.IsValid)
            {
                Kategori kat = new Kategori();
                kat.Adi = kateg;
                makale.Kategori = kat;
                Kullanici k = new Kullanici();
                k = db.Users.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
                makale.Kullanici = k;

                foreach (var item in etik)
                {
                    Etiket e = new Etiket();
                    e.Adi = item;
                    makale.Etiketler.Add(e);
                    db.Etiketler.Add(e);

                }
                db.Resimler.Add(r);
                db.Makaleler.Add(makale);
                db.SaveChanges();

                //return RedirectToAction("Index");
            }

            else
            {
                Kategori kat = new Kategori();
                kat.Adi = kateg;
                makale.Kategori = kat;
                var ku = db.Users.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
                makale.Kullanici = ku;

                foreach (var item in etik)
                {
                    Etiket e = new Etiket();
                    e.Adi = item;
                    makale.Etiketler.Add(e);
                    db.Etiketler.Add(e);

                }
                db.Makaleler.Add(makale);
                db.SaveChanges();
                db.SaveChanges();
            }
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi", makale.KategoriID);
            return Redirect("/Uye/Profil");
        }

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
                return Redirect("/Uye/profil/");
            }
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi", makale.KategoriID);
            return View(makale);
        }

        //GET: Makale/Delete/5
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
            //db.Makaleler.Remove(makale);
            //db.SaveChanges();
            mrep.Delete(id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult MakaleSil(int id)
        {
            try
            {
                var res = db.Resimler.Where(x => x.MakaleID == id).ToList();
                var obj = db.Makaleler.Find(id);
                //obj.Resimler.Remove() ;
                mrep.Delete(id);
                return Json(new { success = true, message = "Silindi" });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Data + "Bir hata oluştu." });
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Ekle()
        {


            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi");

            return View();
        }
        public ActionResult Listele()
        {
            var mak = db.Makaleler.ToList();
            return View(mak);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "MakaleID,Baslik,Icerik,EklenmeTarihi,KategoriID,GoruntulenmeSayisi,Begeni,KullaniciID")] Makale makale, HttpPostedFileBase resim, string etik, string kateg, string kullanicim)
        {

            Resim r = new Resim();
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
                            makale.Resimler.Add(r);
                        }
                        catch { }
                    }
                    if (ModelState.IsValid)
                    {
                        new BLL.BaseRepository<Resim>().Insert(r);
                        #endregion
                        Etiket e = new Etiket();
                        e.Adi = etik;
                        makale.Etiketler.Add(e);
                        db.Etiketler.Add(e);
                        db.Resimler.Add(r);
                        db.Makaleler.Add(makale);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    #endregion
                    else
                    {
                        var ku = db.Users.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
                        makale.Kullanici = ku;
                        Etiket e = new Etiket();
                        e.Adi = etik;
                        makale.Etiketler.Add(e);
                        db.Etiketler.Add(e);
                        db.Makaleler.Add(makale);
                        db.SaveChanges();
                    }
                }
            }
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi", makale.KategoriID);
            return View(makale);

        }

    }
}