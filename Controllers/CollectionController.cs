using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using milkify.Models;

namespace milkify.Controllers
{
    public class CollectionController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
