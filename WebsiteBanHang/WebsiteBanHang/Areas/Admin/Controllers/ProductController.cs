using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models;
using WebsiteBanHang.Models.EF;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Product
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.Id);
            //if (!string.IsNullOrEmpty(SearchText))
            //{
            //    items = items.Where(x => x.Alias.Contains(SearchText) || x.Title.Contains(SearchText));
            //}
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.pageSize = pageSize;
            ViewBag.page = page;
            return View(items);
        }
        public ActionResult Add()
        { 
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, List<string> Images, List<int> rDefault)
        {
           
            if (ModelState.IsValid)
            {
                int ImagesLength = Images.Count;
                if (Images!=null && ImagesLength > 0)
                {
                    for(int i=0;i< ImagesLength; i++)
                    {
                        if (i + 1 == rDefault[0])
                        {
                            model.Image = Images[i];
                            model.ProductImages.Add(new ProductImage
                            {
                                ProductID = model.Id,
                                Image = Images[i],
                                IsDefault = true
                            });

                        }
                        else
                        {
                            
                            model.ProductImages.Add(new ProductImage
                            {
                                ProductID = model.Id,
                                Image = Images[i],
                                IsDefault = false
                            });
                        }
                    }
                }
                model.CreateDate = DateTime.Now;
                model.ModifierDate = DateTime.Now;
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }
                model.Alias = WebsiteBanHang.Models.Commons.Filter.FilterChar(model.Title);
                db.Products.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            var item = db.Products.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {

                db.Products.Attach(model);
                model.ModifierDate = DateTime.Now;
               
                model.Alias = WebsiteBanHang.Models.Commons.Filter.FilterChar(model.Title);
                //db.Entry(model).Property(x => x.Title).IsModified = true;
                //db.Entry(model).Property(x => x.ProductCode).IsModified = true;
                //db.Entry(model).Property(x => x.ProductCategoryID).IsModified = true;
                //db.Entry(model).Property(x => x.Image).IsModified = true;
                //db.Entry(model).Property(x => x.Detail).IsModified = true;
                //db.Entry(model).Property(x => x.Description).IsModified = true;
                //db.Entry(model).Property(x => x.Alias).IsModified = true;
                //db.Entry(model).Property(x => x.Price).IsModified = true;
                //db.Entry(model).Property(x => x.PriceSale).IsModified = true;
                //db.Entry(model).Property(x => x.Quantity).IsModified = true;
                //db.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                //db.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                //db.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                //db.Entry(model).Property(x => x.ModifierDate).IsModified = true;
                //db.Entry(model).Property(x => x.ModifierBy).IsModified = true;
                //db.Entry(model).Property(x => x.IsFeture).IsModified = true;
                //db.Entry(model).Property(x => x.IsSale).IsModified = true;
                //db.Entry(model).Property(x => x.IsHot).IsModified = true;
                //db.Entry(model).Property(x => x.IsHome).IsModified = true;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
                return Json(new { success = true });   
        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var i = db.Products.Find(Convert.ToInt32(item));
                        db.Products.Remove(i);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });

        }
        [HttpPost]
        public ActionResult Active(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).Property(x => x.IsActive).IsModified = true;
                db.SaveChanges();
                return Json(new { success = true, IsActives = item.IsActive });
            }
            return Json(new { success = false });
        }
    }
}