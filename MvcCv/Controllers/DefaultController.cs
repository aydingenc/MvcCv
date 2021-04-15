using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;  
 /*MvcCv projesi içerisnde ki model klasörü içerisinde ki  Entitiy klasörüne ulaş*/
namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        dbCVEntities1 db = new dbCVEntities1();  /*dbCVEntities1 sınıfından db adında bir örnek oluşturdum bu db ile tablolalarıma erişim gerçekleştirecegim.*/
        public ActionResult Index()
        {
            var degerler = db.tbl_Hakkimda.ToList(); /*db sayesinde üzerinde çalışmak istedigim tablomu listeleyip degerler degişkenine attım ve aşagıda bana view sayfasında degerleri dön dedim.*/
            return View(degerler);

            //Şimdi index sayfasında bunları çagıralım
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.tbl_SosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.tbl_Deneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitim()
        {
            var egitimler = db.tbl_Egitimler.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yetenek()
        {
            var yetenekler = db.tbl_Yeteneklerim.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobi()
        {
            var hobiler = db.tbl_Hobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifika()
        {
            var sertifikalar = db.Sertifikalar.ToList(); /*Sertifikaalaar tablomu liste olarak sertifikalar degişkenine at*/
            return PartialView(sertifikalar); /*partialview sayfasını git giderken yanında sertifikalar sayfasını da taşı*/
        }

        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult iletisim(tbl_Iletisim t)   /*tbliletisim sınıfından t adında bir parametre türettim */
        {
            t.Tarih =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tbl_Iletisim.Add(t); /*t den gelen degerler form post edildiginde name degerlerini sırasıyla taşır.*/
            db.SaveChanges();
            return PartialView();
        }
    }
}