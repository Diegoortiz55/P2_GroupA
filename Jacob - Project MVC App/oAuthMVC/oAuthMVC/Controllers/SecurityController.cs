using Microsoft.AspNetCore.Mvc;
using oAuthMVC.Models;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        StoreDBContext db = new StoreDBContext();
        public IActionResult Login()
        {
            ViewBag.response = "";
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = new AuthenticatorUser();
            ViewBag.result = user.CheckUserLogin(username, password).Result;
            if (ViewBag.result == "Login Successfull")
            {
                RedirectToAction("AddProducts", "Products");
            }
            return View();
        }
    }
}
