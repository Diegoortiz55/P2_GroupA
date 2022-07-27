using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace VideoGameStore.Controllers
{
    [Authorize]
    public class SecurityController : Controller
    {   public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
    }
}
