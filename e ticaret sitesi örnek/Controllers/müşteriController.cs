using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using netmvc.Models.entity;

namespace netmvc.Controllers
{
    public class müşteriController : Controller
    {
        // GET: müşteri
        mvcdb_StokEntities1 db = new mvcdb_StokEntities1();

        public ActionResult Index()
        {
            var degerler = db.TBL_MUSTERI.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult yenimusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yenimusteri(TBL_MUSTERI p1)
        {
            db.TBL_MUSTERI.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SİL(int id) //klasör adı ile aynı olması lazım
        {
            var musteri = db.TBL_MUSTERI.Find(id);
            db.TBL_MUSTERI.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult müşterigetir(int id)
        {
            var mus = db.TBL_MUSTERI.Find(id); //id olarak gönderilen değeri bul
            return View("müşterigetir", mus);
        }
        public ActionResult güncelle(TBL_MUSTERI p1)
        {
            var mus = db.TBL_MUSTERI.Find(p1.MUSTERIRID);
            mus.MUSTERIAD = p1.MUSTERIAD; //p1 den gelen müşteri adını mus daki müşteri adına ata
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult örnek()
        {
            return RedirectToAction("Index");
        }
    }
}