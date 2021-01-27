using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;
namespace BonusMvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index( string p)
        {
            // var urunler = db.Tbl_urunler.Where(x=> x.durum == true).ToList();
            var urunler = db.Tbl_urunler.Where(x=> x.durum == true);
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.ad.Contains(p) && x.durum==true );
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.Tbl_kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop = ktg;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Tbl_urunler t)
        {
            var ktgr = db.Tbl_kategori.Where(x => x.id == t.Tbl_kategori.id).FirstOrDefault();
            t.Tbl_kategori = ktgr;
            db.Tbl_urunler.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kat = (from x in db.Tbl_kategori.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();
            var ktgr = db.Tbl_urunler.Find(id);
            ViewBag.urunkategori = kat;
            return View("UrunGetir", ktgr);
        }
        public ActionResult UrunGuncelle(Tbl_urunler p)
        {
            var urun = db.Tbl_urunler.Find(p.id);
            urun.marka = p.marka;
            urun.satisfiyat = p.satisfiyat;
            urun.stok = p.stok;
            urun.alisfiyat = p.alisfiyat;
            urun.ad = p.ad;
            var ktg = db.Tbl_kategori.Where(x => x.id == p.Tbl_kategori.id).FirstOrDefault();
            urun.kategori = ktg.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(Tbl_urunler p)
        {
            var urunbul = db.Tbl_urunler.Find(p.id);
            urunbul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
