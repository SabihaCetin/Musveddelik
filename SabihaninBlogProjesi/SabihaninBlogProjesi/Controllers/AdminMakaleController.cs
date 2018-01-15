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
using System.IO;
using BLL;

namespace SabihaninBlogProjesi.Controllers
{
    [Authorize(Roles = "Admin, Yonetici")]
    public class AdminMakaleController : Controller
    {
        
        MyContext db = new MyContext();

        // GET: AdminMakale
        public ActionResult Index(Kullanici k)
        {
            Session["username"] = k.UserName;
            var Makaleler = db.Makaleler.Include(m => m.Kategori);
            return View(Makaleler.ToList());
        }

        // GET: AdminMakale/Details/5
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


            var kullanici = db.Users.Where(i => i.Email == k.Email).FirstOrDefault();
            var makale = db.Makaleler.Where(x => x.MakaleID == Makaleid).FirstOrDefault();
            db.Yorumlar.Add(new DomainEntity.Yorum { Kullanici = kullanici, Makale = makale, EklenmeTarihi = DateTime.Now, YorumIcerik = yorum });
            db.SaveChanges();
            //return Json(false, JsonRequestBehavior.AllowGet);
        }

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
        public ActionResult Create([Bind(Include = "MakaleID,Baslik,Icerik,EklenmeTarihi,KategoriID,GoruntulenmeSayisi,Begeni,KullaniciID")] Makale makale, HttpPostedFileBase resim, string[] etik, string kullanicim)
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
                var ku = db.Users.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
                makale.Kullanici = ku;

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

                return RedirectToAction("Index");
            }

            else
            {
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
            return View(makale);
        }

        // GET: AdminMakale/Edit/5
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

        // POST: AdminMakale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MakaleID,Baslik,Icerik,EklenmeTarihi,KategoriID,GoruntulenmeSayisi,Begeni,KullaniciID")] Makale makale, HttpPostedFileBase resim, string[] etik)
        {
            Resim r = new Resim();
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
                        r.MakaleID=makale.MakaleID;
                        makale.Resimler.Add(r);
                        new BLL.BaseRepository<Resim>().Insert(r);
                    }
                    catch { }
                }
            }
            if (ModelState.IsValid)
            {

                #endregion

              

                db.Resimler.Add(r);
                foreach (var item in etik)
                {
                  
                    Etiket e = new Etiket();
                    e.Adi =item;
                    makale.Etiketler.Add(e);
                  db.Entry(e).State = EntityState.Added;


                }
//                foreach (var item2 in etik)
//                {
//                    foreach (var item in makale.Etiketler)
//                    {
//                        if (item.Adi==item2)
//                        {
//Etiket e = new Etiket();
//                    e.Adi = item2;
//                    e.EtiketID = makale.MakaleID;
//                            db.Etiketler.Remove(e);
//                        }
//                    }
                    
//                }
                //return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "KAtegoriID", "Adi", makale.KategoriID);
            return View(makale);
        }

        // GET: AdminMakale/Delete/5
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

        // POST: AdminMakale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Makale makale = db.Makaleler.Where(c => c.MakaleID == id).FirstOrDefault();
            if (makale.Etiketler.Count()!=0 || makale.Resimler.Count()!=0 || makale.Yorumlar.Count()!=0)
            {
            foreach (var i in makale.Etiketler.ToList())
            {
                db.Etiketler.Remove(i);
            }
            foreach (var o in makale.Resimler.ToList())
            {
                db.Resimler.Remove(o);
            }
            foreach (var k in makale.Yorumlar.ToList())
            {
                db.Yorumlar.Remove(k);
            }
            }
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
    }
}
