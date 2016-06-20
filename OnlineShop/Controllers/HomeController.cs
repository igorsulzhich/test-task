using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.ProductService;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private ProductServiceClient psc = new ProductServiceClient();

        public ActionResult Index()
        {
            return View(psc.GetAllProducts());
        }
    }
}