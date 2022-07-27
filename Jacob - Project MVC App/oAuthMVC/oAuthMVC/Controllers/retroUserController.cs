using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace oAuthMVC.Controllers
{
    [Authorize]
    public class retroUserController : Controller
    {
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult ShopTitles()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult GameRanking()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Services()
        {
            return View();
        }
    }
}
