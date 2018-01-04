using BLL;
using DAL;
using DomainEntity;
using DomainEntity.Models;
using SabihaninBlogProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabihaninBlogProjesi.Controllers
{
    public class BlogController : Controller
    {
        MyContext db = new MyContext();

        BaseRepository<Ortak> brep = new BaseRepository<Ortak>();
       
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
    //    [ValidateAntiForgeryToken]
        public ActionResult Profil()
        {
           
            var makales = db.Makaleler;
            return View(makales.ToList());
    }
    }
}