using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Models;

namespace VideoGameStore.Controllers
{
/*    [Route("api/[controller]")]
    [ApiController]
*/
    [Authorize] //user will need to identify themself on a login page to get access to actions in this controller
    public class SecurityController : Controller
    {
        StoreDBContext db = new StoreDBContext();
        public IActionResult Login()
        {
            ViewBag.response = "";
            return View();
        }
        public IActionResult Login(string username, string password)
        {
            var user = new AuthenticateUser();
            ViewBag.result = user.CheckUserLogin(username, password).Result;
            if (ViewBag.result == "Login Successfull")
            {
                RedirectToAction("AddProducts", "Products");
            }
            return View();
        }
    }
}
