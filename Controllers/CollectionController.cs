using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using milkify.Models;

namespace milkify.Controllers
{
    public class CollectionController : Controller
    {
        UserDBContext db;
        IWebHostEnvironment env;
        public CollectionController(UserDBContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(db.MilkCollections.ToList());
        }

        public IActionResult AddCollection()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]  
        public IActionResult AddCollection(MilkCollection milk)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if(milk != null)
            {
                MilkCollection m = new MilkCollection()
                {
                    FarmerName = milk.FarmerName,
                    CollectionDate = milk.CollectionDate,
                    Quantity = milk.Quantity,
                    RatePerLiter = milk.RatePerLiter,
                    MilkType = milk.MilkType,
                    Status = milk.Status
                };
                db.MilkCollections.Add(m);
                db.SaveChanges();
                TempData["Succes"] = "Collection added..";
                return RedirectToAction("Index", "Collection");
            }
            return View();
        }
    }
}
