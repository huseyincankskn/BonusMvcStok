using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;

namespace BonusMvcStok.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var satislar = db.tbl_satislar.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //ÜRÜNler
            List<SelectListItem> urun = (from x in db.Tbl_urunler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.drop1 = urun;

            //Personel
            List<SelectListItem> per = (from x in db.tbl_personel.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad + " "+  x.soyad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop2 = per;

            //Müşteriler
            List<SelectListItem> musteri = (from x in db.tbl_musteri.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ad + " " + x.soyad,
                                                Value = x.id.ToString()
                                            }).ToList();
            ViewBag.drop3 = musteri;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tbl_satislar p)
        {
            var urun = db.Tbl_urunler.Where(x => x.id == p.Tbl_urunler.id).FirstOrDefault();
            var musteri = db.tbl_musteri.Where(x => x.id == p.tbl_musteri.id).FirstOrDefault();
            var personel = db.tbl_personel.Where(x => x.id == p.tbl_personel.id).FirstOrDefault();
            p.Tbl_urunler = urun;
            p.tbl_musteri = musteri;
            p.tbl_personel = personel;
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tbl_satislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }
    }
}