
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using netmvc.Models.entity;

namespace netmvc.Controllers
{
    public class kategori2Controller : Controller
    {
        // GET: kategori2
        mvcdb_StokEntities2 ab = new mvcdb_StokEntities2();
        public ActionResult Index()
        {
            var goruntu = ab.TBL_KATEGORI.ToList();

            return View(goruntu);
        }
        [HttpGet]
        public ActionResult yenikategori2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenikategori2(TBL_KATEGORI p1)
        {
            ab.TBL_KATEGORI.Add(p1);
            ab.SaveChanges();
            return View();
        }
        public ActionResult sil( int id)
        {
            var kategori = ab.TBL_KATEGORI.Find(id);
            ab.TBL_KATEGORI.Remove(kategori);
            return View();
        }
    }
}