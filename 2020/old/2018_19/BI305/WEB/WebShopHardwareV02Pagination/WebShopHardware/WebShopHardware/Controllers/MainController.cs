using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopHardware.Domains;

namespace WebShopHardware.Controllers
{
    public class MainController : Controller
    {
        private ModelHardwareContainer _db;
        private int pageSize = 3;

        public MainController()
        {
            _db = new ModelHardwareContainer();
        }

        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products(int page)
        {
            int quantity = _db.Products.Count();
            int totalPages = (int)
                Math.Ceiling(
                quantity / (float)pageSize);
            ViewBag.Pages = totalPages;
            ViewBag.Active = page;

            var pageList =
                _db
                .Products
                .OrderBy(x=>x.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return View(pageList);
        }
    }
}