using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;
using System.Web.Security;

namespace BonusMvcStok.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(tbl_admin t)
        {
            var bilgiler = db.tbl_admin.FirstOrDefault(x=>x.kullanici==t.kullanici && x.sifre==t.sifre);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                return View();
            }
            
        }
    }
}