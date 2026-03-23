using GlobalMart.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMart.Controllers
{
    public class ProductsController : Controller
    {
        private IPricingService _pricingService;

        public ProductsController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }
        public IActionResult Index()
        {
            double price = 1000;
            ViewBag.price = price;
            ViewBag.winter = _pricingService.Winter25(price);
            ViewBag.freeship = _pricingService.Freeship(price);
            return View();
        }
    }
}
