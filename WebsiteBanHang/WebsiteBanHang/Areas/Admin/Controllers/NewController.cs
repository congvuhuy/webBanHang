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
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
    }
}