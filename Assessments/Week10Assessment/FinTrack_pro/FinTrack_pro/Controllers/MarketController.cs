using Microsoft.AspNetCore.Mvc;

namespace FinTrack_pro.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MarketStatus = "Closed";
            ViewData["TopGainer"] = "FinPro";
            TempData["Volume"] = 89;
            return View();
        }
        [HttpGet("Analyze/{ticker}/{days:int?}")]
        public IActionResult Search(string ticker, int? days)
        {
            if (days == null)
                days = 30;

            ViewBag.ticker = ticker;
            ViewBag.days = days;
            ViewData["TopGainer"] = ticker;
            TempData["Volume"] = days * 10;

            return View();
        }
    }
}
