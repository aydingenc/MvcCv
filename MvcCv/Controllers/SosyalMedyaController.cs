using MvcCv.Models.Entity;
using MvcCv.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<tbl_SosyalMedya> repo = new GenericRepository<tbl_SosyalMedya>();

        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tbl_SosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.Id == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(tbl_SosyalMedya p)
        {
            var hesap = repo.Find(x => x.Id ==p.Id);
            hesap.Durum = true;
            hesap.Ad = p.Ad;
            hesap.Link = p.Link;
            hesap.ikon = p.ikon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.Id == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}