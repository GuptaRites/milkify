using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            //if (HttpContext.Session.GetString("UserName") == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
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
            if(pord != null)
            {
               string folder = Path.Combine(env.WebRootPath, "img");
                filename = Guid.NewGuid().ToString() +"_"+ pord.photo.FileName;
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
    }
}
