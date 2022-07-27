using Microsoft.AspNetCore.Mvc;
using oAuthMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoGameStore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : Controller
    {
        StoreDBContext db = new StoreDBContext();

        //// GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}


        public IActionResult SetRanking(string gameName, int gameRanking)
        {
            Ranking ranking = new Ranking();
            ranking.productRanking = gameRanking;
            ranking.productName = gameName;
            db.Rankings.Add(ranking);
            db.SaveChanges();

            return RedirectToAction("Rankings", new { name = gameName});
        }

    }
}

