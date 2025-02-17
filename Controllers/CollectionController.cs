using Microsoft.AspNetCore.Mvc;

namespace milkify.Controllers
{
    public class CollectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
