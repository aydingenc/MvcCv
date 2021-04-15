using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Repositories;
using MvcCv.Models.Entity;
namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<tbl_Admin> repo = new GenericRepository<tbl_Admin>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(tbl_Admin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            tbl_Admin t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            tbl_Admin t = repo.Find(x => x.Id == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult AdminDuzenle(tbl_Admin p)
        {
            tbl_Admin t = repo.Find(x => x.Id == p.Id);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;           
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
    
