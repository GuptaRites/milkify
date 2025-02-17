using Microsoft.AspNetCore.Mvc;

namespace milkify.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
