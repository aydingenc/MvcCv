using MvcCv.Models.Entity;
using MvcCv.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<tbl_Egitimler> repo = new GenericRepository<tbl_Egitimler>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(tbl_Egitimler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.Id == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
            public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.Id == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(tbl_Egitimler t)
        {
            var egitim = repo.Find(x => x.Id == t.Id);
            egitim.Baslik = t.Baslik;
            egitim.AltBaslik1 = t.AltBaslik1;
            egitim.AltBaslik2 = t.AltBaslik2;
            egitim.GNO = t.GNO;
            egitim.Tarih = t.Tarih;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");

        }
    }
}