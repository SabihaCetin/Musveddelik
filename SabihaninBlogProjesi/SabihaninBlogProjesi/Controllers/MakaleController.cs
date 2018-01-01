using BLL;
using DomainEntity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabihaninBlogProjesi.Controllers
{
    public class MakaleController : Controller
    {
        MakaleRep brep = new MakaleRep();
        // GET: Makale
        public ActionResult Index()
        {
            List<Makale> Makaleler = brep.GetAll();
            return View(Makaleler);
        }
        [HttpGet]
        public ActionResult MakaleEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MakaleEkle(Makale m, HttpPostedFileBase resim)
        {
            try
            {
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
                            m.MakaleResim = dosyaAdi;//buraya girmiyor neden ?
                        }
                       catch { }
                    }
                  //  if (ModelState.IsValid)
                        brep.Insert(m);
                    ViewBag.Sonuc = "Ekleme başarılı...";
                }
            }
            catch (Exception)
            { }
            return View(); 
        }
        [HttpPost]
        public JsonResult MakaleSil(int id)
        {
            try
            {
                
                brep.Delete(id);
                return Json(new { success = true, message = "Silindi" });
            }
            catch 
            {
                
                return Json(new { success = false, message = "Bir hata oluştu." });
            }
        }
        public ActionResult MakaleDetay(int id)
        {
            return View(brep.GetById(id));
        }
        public ActionResult MakaleDuzenle(int id)
        {
            return View(brep.GetById(id));
        }
        [HttpPost]
        public ActionResult MakaleDuzenle(Makale m, HttpPostedFileBase MakaleURL)
        {
            Makale yazı=brep.GetById(m.MakaleID);
            yazı.Baslik = m.Baslik;
            yazı.Icerik = m.Icerik;
            yazı.Tanım = m.Tanım;
            yazı.YazarEmail = m.YazarEmail;
            brep.Update(yazı);
            return RedirectToAction("Index");
        }
    }
}