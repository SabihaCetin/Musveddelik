using BLL;
using DAL;
using DomainEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabihaninBlogProjesi.Controllers
{
    [Authorize(Roles = "Admin, Yonetici")]
    public class AdminController : Controller
    {
        MakaleRep mrep = new MakaleRep();
        MyContext db = new MyContext();
        // GET: Admin
        public ActionResult Index()
        {//admin temasını ekle
            return View();
        }
        public ActionResult AdminMakale()
        {
            List<Makale> mak = db.Makaleler.ToList();
            return View(mak);
        }
    }
}