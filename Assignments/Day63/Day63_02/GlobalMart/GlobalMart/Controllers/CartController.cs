using System.Data;
using GlobalMart.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMart.Controllers
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
            double item1 = 100;
            double item2 = 200;
            double item3 = 250;
            double total = item1 + item2 + item3;
            double discounted = _pricingService.Winter25(total);

            ViewBag.Total = total;
            ViewBag.FinalTotal = discounted;
            return View();
        }
    }
}
