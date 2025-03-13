using Microsoft.AspNetCore.Mvc;

namespace milkify.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
