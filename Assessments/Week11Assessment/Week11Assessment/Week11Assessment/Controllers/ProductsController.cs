using Microsoft.AspNetCore.Mvc;
using Week11Assessment.Services;

namespace Week11Assessment.Controllers
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

            double price = 5000;
            ViewBag.Price = price;
            ViewBag.winter = _pricingService.ApplyDiscount(price,"WINTER25");
            ViewBag.freeship = _pricingService.ApplyDiscount(price,"FREESHIP");
            return View();
        }
    }
}
