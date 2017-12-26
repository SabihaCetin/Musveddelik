using BLL;
using DAL;
using DomainEntity;
using DomainEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabihaninBlogProjesi.Controllers
{
    public class BlogController : Controller
    {
        BaseRepository<OrtakKullaniciMakale> brep = new BaseRepository<OrtakKullaniciMakale>();
        MyContext db = new MyContext();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Profil(string email)
        {
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        //  var kullanici = db.Users.Where(x => x.Email == email).FirstOrDefault();
        //        List<Makale> kullanicininMakaleleri = db.Makaleler.Where(x => x.YazarEmail == email).ToList();
        //        return View(kullanicininMakaleleri);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
   
            List<Makale> kullanicininMakaleleri = db.Makaleler.Where(x => x.YazarEmail == email).ToList();
            
            return View(kullanicininMakaleleri);
    }
    }
}