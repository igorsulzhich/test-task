using System.Web;
using System.Web.Mvc;
using OnlineShop.ProductService;
using System.Net;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
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
        public ActionResult Create(Products item, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                    psc.ProductNew(item, psc.FileImport(upload.InputStream));

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
        public ActionResult Edit(Products item, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string publicId = null;

                if (upload != null)
                    publicId = psc.FileImport(upload.InputStream);

                psc.ProductUpdate(item, publicId);
                return RedirectToAction("Index");
            }
            return View();
        }

        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            psc.ProductDelete(psc.Search(id));
            return RedirectToAction("Index");
        }
    }
}