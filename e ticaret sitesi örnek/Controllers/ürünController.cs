using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using netmvc.Models.entity;

namespace netmvc.Controllers
{
    public class ürünController : Controller
    {
        // GET: ürün
        mvcdb_StokEntities1 db = new mvcdb_StokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBL_URUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ürünekle()
        {
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult ürünekle(TBL_URUNLER p1)
        {
            var ktg=db.TBL_KATEGORI.Where(m=>m.KATEGORIID==p1.TBL_KATEGORI.KATEGORIID).FirstOrDefault();
            p1.TBL_KATEGORI = ktg;
            db.TBL_URUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SİL(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);
            db.TBL_URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult urungetir(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("urungetir", urun);
        }
        public ActionResult güncelle(TBL_URUNLER p)
        {
            var urun = db.TBL_URUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FIYAT = p.FIYAT;
            // urun.URUNKATEGORI = p.URUNKATEGORI;
            var ktg = db.TBL_KATEGORI.Where(m => m.KATEGORIID == p.TBL_KATEGORI.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}