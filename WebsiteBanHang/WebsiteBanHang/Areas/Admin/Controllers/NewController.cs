using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models;
using WebsiteBanHang.Models.EF;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class NewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/New
        public ActionResult Index()
        {
            var items = db.News;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(New model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.ModifierDate = DateTime.Now;
                model.CategoryID = 1;
                model.Alias = WebsiteBanHang.Models.Commons.Filter.FilterChar(model.Title);
                db.News.Add(model);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}