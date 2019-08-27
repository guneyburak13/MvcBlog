using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Models;

namespace MvcBlog.Controllers
{
    public class AdminController : Controller
    {
        mvcblogDB db = new mvcblogDB();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.MakaleSayisi = db.Makale.Count();
            ViewBag.YorumSayisi = db.Yorum.Count();
            ViewBag.KategoriSayisi = db.Kategori.Count();
            ViewBag.UyeSayisi = db.Uye.Count();
            return View();
        }
    }
}