using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            double price = 5000;
            double price2 = 2000;
            double price3 = 3000;
            double total = price + price2 + price3;
            ViewBag.BeforeDiscount = total;
            ViewBag.FinalTotal = _pricingService.ApplyDiscount(total,"WINTER25");
            return View();
        }
    }
}
