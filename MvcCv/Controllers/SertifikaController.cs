using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Models.Repositories;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<Sertifikalar> repo = new GenericRepository<Sertifikalar>();
        // GET: Sertifika
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.Id == id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(Sertifikalar t)
        {
            var sertifika = repo.Find(x => x.Id == t.Id);
            sertifika.Sertifikalarım = t.Sertifikalarım;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(Sertifikalar t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.Id == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}