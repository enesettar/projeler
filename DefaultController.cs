using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DistinctBlog.Models.entity;
using DistinctBlog.Models.sınıfım;

namespace DistinctBlog.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        dbmvcblogyeniEntities db = new dbmvcblogyeniEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger1 = db.TBLHAKKIMDA.ToList();
            cs.deger2 = db.TBLILETISIM.ToList();
            
            return View(cs);
        }
    }
}