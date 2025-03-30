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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var supplier = db.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Supplier sup)
        {
            if (id != sup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                db.Suppliers.Update(sup);
                db.SaveChanges();
                TempData["Succes"] = "Supplier updated successfully!";
                return RedirectToAction("Index");
            }

            return View(sup);
        }

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var supplier = db.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var supplier = db.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var supplier = db.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier != null)
            {
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
                TempData["Succes"] = "Supplier deleted.";
            }

            return RedirectToAction("Index");
        }

    }
}
