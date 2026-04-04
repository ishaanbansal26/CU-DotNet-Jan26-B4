using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week11Assessment.Services;

namespace Week11Assessment.Controllers
{
    public class CartController : Controller
    {
        private IPricingService _pricingService;

        public CartController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }
        public IActionResult Index(double price,string code)
        {
            //double price = 5000;
            //double price2 = 2000;
            //double price3 = 3000;
            //double total = price + price2 + price3;
            ViewBag.BeforeDiscount = price;
            ViewBag.code = code;
            ViewBag.FinalTotal = _pricingService.ApplyDiscount(price,code);
            return View();
        }

        [HttpPost]
        public IActionResult GoToCart(double price,string code)
        {
            return RedirectToAction(nameof(Index), new { price, code });
        }
    }
}
