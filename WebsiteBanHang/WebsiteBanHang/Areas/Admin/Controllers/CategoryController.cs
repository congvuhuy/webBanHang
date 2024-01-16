using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models;
using WebsiteBanHang.Models.EF;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = db.Categories;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.ModifierDate = DateTime.Now;
                model.Alias = WebsiteBanHang.Models.Commons.Filter.FilterChar(model.Title);
                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            
            return View();
        }
    }
}