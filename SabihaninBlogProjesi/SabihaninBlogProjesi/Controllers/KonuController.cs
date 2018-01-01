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

namespace SabihaninBlogProjesi.Controllers
{
    public class KonuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        MyContext mc = new MyContext();
     //   BaseRepository<Konu> brep = new BaseRepository<Konu>();

        // GET: Konu
        public ActionResult Index()
        {
            // var konus = db.Konus.Include(k => k.UstKonu);
            var konus = mc.Konular.Include(k => k.UstKonu);
            return View(konus.ToList());
        }

        // GET: Konu/Details/5
        public ActionResult Detay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //      Konu konu = db.Konus.Find(id);
            Konu konu = mc.Konular.Find(id);
            if (konu == null)
            {
                return HttpNotFound();
            }
            return View(konu);
        }

        // GET: Konu/Create
        public ActionResult KonuEkle()
        {
            //ViewBag.UstKonuID = new SelectList(db.Konus, "KonuID", "KonuBaslik");
            ViewBag.UstKonuID = new SelectList(mc.Konular, "KonuID", "KonuBaslik");
            return View();
        }

        // POST: Konu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult KonuEkle([Bind(Include = "KonuID,KonuBaslik,KonuIcerik,UstKonuID")] Konu konu, HttpPostedFileBase resim)
        {
            //if (ModelState.IsValid)
            //{
            //    //db.Konus.Add(konu);
            //    //db.SaveChanges();
            //    mc.Konular.Add(konu);
            //    mc.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            // ViewBag.UstKonuID = new SelectList(db.Konus, "KonuID", "KonuBaslik", konu.UstKonuID);
            ViewBag.UstKonuID = new SelectList(mc.Konular, "KonuID", "KonuBaslik", konu.UstKonuID);
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
                        konu.KonuResim = dosyaAdi;
                    }
                    catch { }
                }
                if (ModelState.IsValid)
                    new BLL.BaseRepository<Konu>().Insert(konu);
            }
           BLL.BaseRepository<Konu> br = new BLL.BaseRepository<Konu>();

            return RedirectToAction("Index");
        }

        // GET: Konu/Edit/5
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konu konu = db.Konus.Find(id);
            if (konu == null)
            {
                return HttpNotFound();
            }
            ViewBag.UstKonuID = new SelectList(db.Konus, "KonuID", "KonuBaslik", konu.UstKonuID);
            return View(konu);
        }
        // POST: Konu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "KonuID,KonuBaslik,KonuIcerik,UstKonuID")] Konu konu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(konu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UstKonuID = new SelectList(db.Konus, "KonuID", "KonuBaslik", konu.UstKonuID);
            return View(konu);
        }

        // POST: Konu/Delete/5
        [HttpPost]
        public JsonResult KonuSil(int id)
        {
            try
            {
                var secilikonu = mc.Konular.Where(x => x.KonuID == id).FirstOrDefault();
                mc.Konular.Remove(secilikonu);
                return Json(new { success = true, message = "Silindi" });
            }
            catch
            {
                return Json(new { success = false, message = "Bir hata oluştu." });
            }
        }

        

        //// POST: Konu/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Sil(int id)
        //{
        //    Konu konu = db.Konus.Find(id);
        //    db.Konus.Remove(konu);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
