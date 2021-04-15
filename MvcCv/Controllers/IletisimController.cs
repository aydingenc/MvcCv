using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Repositories;
using MvcCv.Models.Entity;
namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<tbl_Iletisim> repo = new GenericRepository<tbl_Iletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}