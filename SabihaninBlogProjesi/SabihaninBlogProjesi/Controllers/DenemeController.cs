using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabihaninBlogProjesi.Areas.Admin.Controllers
{
    public class DenemeController : Controller
    {
        MakaleRep mrep = new MakaleRep();
        MyContext db = new MyContext();
        // GET: Admin/Deneme
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult TemaMakale()
        {
            var makales = db.Makaleler.ToList();

            return View(makales.ToList());
        }
       
       
     
    }
}