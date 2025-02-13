using Microsoft.AspNetCore.Mvc;

namespace milkify.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserRegistration()
        {
            return View();
        }
        public IActionResult UserLogin()
        {
            return View();
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
    }
}
