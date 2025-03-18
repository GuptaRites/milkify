using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using milkify.Models;

namespace milkify.Controllers
{
    public class SupplierController : Controller
    {
        UserDBContext db;
        IWebHostEnvironment env;
        public SupplierController(UserDBContext db, IWebHostEnvironment env)
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
            return View(db.Suppliers.ToList());
        }
        public IActionResult AddSupplier()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddSupplier(Supplier sup)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (sup != null)
            {
                Supplier s = new Supplier()
                {
                    Name = sup.Name,
                    Address = sup.Address,
                    ContactNumber = sup.ContactNumber,
                    Email = sup.Email,
                    RegisteredDate = sup.RegisteredDate,
                    Status = sup.Status
                };
                db.Suppliers.Add(s);
                db.SaveChanges();
                TempData["Succes"] = "Supplier added..";
                return RedirectToAction("Index", "Supplier");
            }
            return View();
        }
    }
}
