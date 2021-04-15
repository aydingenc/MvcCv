using MvcCv.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository(); /*DeneyimRepositoryi kullanabilmek adına çagırdım*/
        public ActionResult Index()
        {
            var deneyimler = repo.List(); // Deneyimrepository içinin boş olmasına ragmen repo. diyerek metotları getirmesinin sebebi genericrepositoryden kalıtım almasından kaynaklı.
            return View(deneyimler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(tbl_Deneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            tbl_Deneyimlerim t = repo.Find(x => x.Id == id);
                repo.TDelete(t);    
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            tbl_Deneyimlerim t = repo.Find(x => x.Id == id);
            return View(t);
            
        }
        [HttpPost]
        public  ActionResult DeneyimGetir(tbl_Deneyimlerim p)
        {
            tbl_Deneyimlerim t = repo.Find(x => x.Id == p.Id);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}