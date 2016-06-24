using System.Web.Mvc;
using OnlineShop.ProductService;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private ProductServiceClient psc = new ProductServiceClient();

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetAll()
        {
            Products[] listProducts = psc.GetAllProducts();
            return PartialView(listProducts);
        }
    }
}