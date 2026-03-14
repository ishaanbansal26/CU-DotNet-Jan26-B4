using Microsoft.AspNetCore.Mvc;

namespace FinTrack_pro.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MarketStatus = "Closed";
            ViewData["TopGainer"] = "FinPro";
            ViewData["Volume"] = 89;
            return View();
        }
        [HttpGet("Analyze/{ticker}/{days:int?}")]
        public IActionResult Search(string ticker, int? days)
        {
            ViewBag.ticker = ticker;
            ViewBag.days = days;
            return View();
        }
    }
}
