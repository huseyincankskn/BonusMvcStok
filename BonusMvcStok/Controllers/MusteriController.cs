using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace BonusMvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            // var musteriliste = db.tbl_musteri.ToList();
            var musteriliste = db.tbl_musteri.Where(x=>x.durum==true).ToList().ToPagedList(sayfa, 3);
            return View(musteriliste);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tbl_musteri p)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            p.durum = true;
            db.tbl_musteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(tbl_musteri p)
        {
            var musteribul = db.tbl_musteri.Find(p.id);
            musteribul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tbl_musteri.Find(id);
            return View("MusteriGetir", mus);

        }
        public ActionResult MusteriGuncelle(tbl_musteri p)
        {
            var mus = db.tbl_musteri.Find(p.id);
            mus.ad = p.ad;
            mus.soyad = p.soyad;
            mus.sehir = p.sehir;
            mus.bakiye = p.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}