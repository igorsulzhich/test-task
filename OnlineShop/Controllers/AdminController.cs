using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.ProductService;
using System.Net;

namespace OnlineShop.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private ProductServiceClient psc = new ProductServiceClient();

        public ActionResult Index()
        {
            return View(psc.GetAllProducts());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products item)
        {
            if (ModelState.IsValid)
            {
                psc.ProductNew(item);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products item = psc.Search(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products item)
        {
            if (ModelState.IsValid)
            {
                psc.ProductUpdate(item);
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(int? id)
        {
            if (ModelState.IsValid)
            {
                psc.ProductDelete(psc.Search(id));
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}