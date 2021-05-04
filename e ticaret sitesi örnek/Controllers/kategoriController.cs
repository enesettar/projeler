using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using netmvc.Models.entity;
using PagedList;
using PagedList.Mvc;



namespace netmvc.Controllers
{
    public class kategoriController : Controller
    {
        // GET: kategori
        mvcdb_StokEntities1 db = new mvcdb_StokEntities1();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBL_KATEGORI.ToList(); //db nesnesinde tbl_kategori içindeki değerleri listele
            var degerler = db.TBL_KATEGORI.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult yenikategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenikategori(TBL_KATEGORI p1)
        {
            db.TBL_KATEGORI.Add(p1);
            db.SaveChanges();
            return View();

        }
        public ActionResult SİL(int id)
        {
            var kategori = db.TBL_KATEGORI.Find(id); //tbl kategori içerisnden gelen id değerinin bul
            db.TBL_KATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult kategorigetir(int id)
        {
            var ktgr = db.TBL_KATEGORI.Find(id);
            return View("kategorigetir", ktgr);
        }
         public ActionResult güncelle(TBL_KATEGORI p1) //parmetreye göre güncellenecek 
        {
            var ktg = db.TBL_KATEGORI.Find(p1.KATEGORIID); //kategori de p den gönderdiğim id ye göre bulur
            ktg.KATEGORIAD = p1.KATEGORIAD; //ktg 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}