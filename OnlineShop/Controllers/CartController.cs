using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.ProductService;
using OnlineShop.Entities;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private ProductServiceClient psc = new ProductServiceClient();

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(Cart cart, int productId)
        {
            Products pr = psc.Search(productId);

            if (pr != null)
            {
                cart.AddItem(pr, 1);
            }
            return RedirectToAction("Summary");
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId)
        {
            Products pr = psc.Search(productId);

            if (pr != null)
            {
                cart.RemoveLine(pr);
            }
            return RedirectToAction("Purchases");
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ActionResult Purchases(Cart cart)
        {
            return PartialView(new CartIndexViewModel
            {
                Cart = cart
            });
        }
    }
}
