using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using milkify.Models;

namespace milkify.Controllers
{
    public class ProductController : Controller
    {
        UserDBContext db;
        IWebHostEnvironment env;
        public ProductController(UserDBContext db, IWebHostEnvironment env)
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
            return View(db.Products.ToList());
        }
        public IActionResult AddProduct()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel pord)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            string filename = "";
            if (pord != null)
            {
                string folder = Path.Combine(env.WebRootPath, "img");
                filename = Guid.NewGuid().ToString() + "_" + pord.photo.FileName;
                string filepath = Path.Combine(folder, filename);
                pord.photo.CopyTo(new FileStream(filepath, FileMode.Create));

                Product p = new Product()
                {
                    ImagePath = filename,
                    Type = pord.Type,
                    Title = pord.Title,
                    Price = pord.Price,
                    Desc = pord.Desc
                };
                db.Products.Add(p);
                db.SaveChanges();
                TempData["Succes"] = "Product added..";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Product p = db.Products.FirstOrDefault(x => x.Id == id);
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Title,Price,Desc,ImagePath")] Product updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingProduct = await db.Products.FindAsync(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                // Update allowed fields
                existingProduct.Type = updatedProduct.Type;
                existingProduct.Title = updatedProduct.Title;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Desc = updatedProduct.Desc;
                // Leave ImagePath unchanged

                await db.SaveChangesAsync();

                TempData["Success"] = "Product updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(updatedProduct);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product != null)
            {
                // Optionally delete image file from wwwroot/img
                string imagePath = Path.Combine(env.WebRootPath, "img", product.ImagePath);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                db.Products.Remove(product);
                await db.SaveChangesAsync();
                TempData["Success"] = "Product deleted successfully.";
            }

            return RedirectToAction(nameof(Index));
        }

    }
}